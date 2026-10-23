(function(){var SHOW=20000,EVERY=12*60*1000,until=0,hideT=null;
function notices(){return Array.from(document.querySelectorAll(".isa-notice")).filter(function(el){return!el.classList.contains("isa-notice--soft");});}
function setV(on){notices().forEach(function(el){el.classList.toggle("isa-notice--hidden",!on);});}
function burst(){until=Date.now()+SHOW;setV(true);if(hideT)clearTimeout(hideT);hideT=setTimeout(function(){setV(false);},SHOW);}
function sync(){setV(Date.now()<until);}
function start(){burst();setInterval(burst,EVERY);}
if(document.readyState==="loading")document.addEventListener("DOMContentLoaded",start);else start();
document.addEventListener("enhancedload",sync);
})();
