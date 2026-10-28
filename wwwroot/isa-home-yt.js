// Continuous ISACA YouTube playlist for Home page
// Priority video (cIxtlh_LuR4) is forced every 30 minutes
window.isaHomeYt = (function () {
  var player = null;
  var ids = [];
  var index = 0;
  var priorityId = "cIxtlh_LuR4";
  var priorityMs = 30 * 60 * 1000; // 30 minutes
  var lastPriorityAt = 0;
  var priorityTimer = null;
  var ready = false;

  function ensureApi(cb) {
    if (window.YT && window.YT.Player) { cb(); return; }
    var prev = window.onYouTubeIframeAPIReady;
    window.onYouTubeIframeAPIReady = function () {
      if (typeof prev === "function") prev();
      cb();
    };
    if (!document.getElementById("yt-iframe-api")) {
      var s = document.createElement("script");
      s.id = "yt-iframe-api";
      s.src = "https://www.youtube.com/iframe_api";
      document.head.appendChild(s);
    }
  }

  function playId(id) {
    if (!player || !id) return;
    var i = ids.indexOf(id);
    if (i >= 0) index = i;
    try {
      player.loadVideoById({ videoId: id, startSeconds: 0 });
    } catch (e) {}
  }

  function playAt(i) {
    if (!player || !ids.length) return;
    // If 30 min elapsed, force priority video instead
    if (Date.now() - lastPriorityAt >= priorityMs) {
      forcePriority();
      return;
    }
    index = ((i % ids.length) + ids.length) % ids.length;
    playId(ids[index]);
  }

  function forcePriority() {
    lastPriorityAt = Date.now();
    playId(priorityId);
  }

  function schedulePriority() {
    if (priorityTimer) clearInterval(priorityTimer);
    priorityTimer = setInterval(function () {
      forcePriority();
    }, priorityMs);
  }

  function start(elementId, videoIds, startIndex, priorityVideoId) {
    ids = (videoIds || []).slice();
    if (priorityVideoId) priorityId = priorityVideoId;
    // Ensure priority is in the list
    if (ids.indexOf(priorityId) < 0) ids.unshift(priorityId);
    if (!ids.length) return;

    // Random start (but not necessarily priority)
    index = Math.max(0, (typeof startIndex === "number" ? startIndex : Math.floor(Math.random() * ids.length)) % ids.length);
    lastPriorityAt = Date.now(); // start 30-min clock now

    ensureApi(function () {
      if (player) {
        try { player.destroy(); } catch (e) {}
        player = null;
      }
      player = new YT.Player(elementId, {
        width: "100%",
        height: "100%",
        videoId: ids[index],
        playerVars: {
          autoplay: 1,
          mute: 1,
          controls: 1,
          rel: 0,
          modestbranding: 1,
          playsinline: 1,
          fs: 1,
          enablejsapi: 1
        },
        events: {
          onReady: function (e) {
            ready = true;
            try { e.target.mute(); e.target.playVideo(); } catch (err) {}
            schedulePriority();
          },
          onStateChange: function (e) {
            if (e.data === YT.PlayerState.ENDED) {
              playAt(index + 1);
            }
          },
          onError: function () {
            playAt(index + 1);
          }
        }
      });
    });
  }

  function stop() {
    if (priorityTimer) { clearInterval(priorityTimer); priorityTimer = null; }
    if (player) {
      try { player.destroy(); } catch (e) {}
      player = null;
    }
    ready = false;
  }

  return { start: start, stop: stop };
})();
