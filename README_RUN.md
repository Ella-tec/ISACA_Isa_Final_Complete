<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>TRU | Trusted Resource & Unified Support</title>

<link href="https://fonts.googleapis.com/css2?family=Roboto:wght@300;400;500;700;900&display=swap" rel="stylesheet">

<style>
:root{
    --primary:#0A2A66;
    --secondary:#14B89A;
    --light:#F8FAFC;
    --white:#FFFFFF;
    --text:#374151;
    --border:#E5E7EB;
}

*{
    margin:0;
    padding:0;
    box-sizing:border-box;
}

body{
    font-family:'Roboto',sans-serif;
    background:#ffffff;
    color:var(--text);
}

header{
    background:#ffffff;
    border-bottom:1px solid var(--border);
    padding:20px 50px;
}

.nav{
    display:flex;
    justify-content:space-between;
    align-items:center;
    max-width:1400px;
    margin:auto;
}

.brand{
    display:flex;
    align-items:center;
    gap:15px;
}

.brand-icon{
    width:60px;
    height:60px;
    border-radius:50%;
    background:linear-gradient(135deg,#0A2A66,#14B89A);
    display:flex;
    align-items:center;
    justify-content:center;
    color:white;
    font-weight:900;
    letter-spacing:1px;
    box-shadow:0 10px 25px rgba(20,184,154,.25);
}

.brand-name{
    font-size:32px;
    font-weight:800;
    color:var(--primary);
}

.brand-tag{
    color:var(--secondary);
    font-size:14px;
}

.hero{
    max-width:1400px;
    margin:auto;
    padding:100px 30px;
    text-align:center;
    background:
    radial-gradient(circle at top right,
    rgba(20,184,154,.08),
    transparent 35%);
}

.hero h1{
    font-size:85px;
    color:var(--primary);
    margin-bottom:15px;
    font-weight:900;
}

.hero h1 span{
    color:var(--secondary);
}

.tagline{
    color:var(--secondary);
    font-size:28px;
    font-weight:600;
    margin-bottom:25px;
}

.hero-description{
    max-width:900px;
    margin:auto;
    line-height:1.9;
    font-size:20px;
    color:#555;
}

.button-group{
    margin-top:40px;
}

.button{
    display:inline-block;
    text-decoration:none;
    background:var(--secondary);
    color:white;
    padding:15px 35px;
    border-radius:14px;
    font-weight:700;
    transition:.3s;
}

.button:hover{
    transform:translateY(-3px);
}

.creator-card{
    max-width:750px;
    margin:70px auto;
    background:var(--light);
    border:1px solid var(--border);
    border-radius:25px;
    padding:40px;
    box-shadow:0 15px 40px rgba(0,0,0,.05);
}

.creator-card h2{
    color:var(--primary);
    font-size:36px;
    margin-bottom:10px;
}

.role{
    color:var(--secondary);
    font-size:20px;
    font-weight:700;
    margin-bottom:20px;
}

.creator-card p{
    line-height:1.9;
    color:#555;
}

.section{
    max-width:1400px;
    margin:auto;
    padding:20px 30px 80px;
}

.section-title{
    text-align:center;
    font-size:48px;
    color:var(--primary);
    margin-bottom:50px;
}

.features{
    display:grid;
    grid-template-columns:repeat(auto-fit,minmax(280px,1fr));
    gap:25px;
}

.feature{
    padding:30px;
    background:white;
    border:1px solid var(--border);
    border-radius:20px;
    transition:.3s;
}

.feature:hover{
    transform:translateY(-5px);
    box-shadow:0 12px 30px rgba(0,0,0,.08);
}

.feature h3{
    color:var(--primary);
    margin-bottom:12px;
}

.feature p{
    line-height:1.8;
    color:#555;
}

footer{
    text-align:center;
    background:#F9FAFB;
    border-top:1px solid var(--border);
    padding:50px 25px;
}

footer h2{
    color:var(--primary);
    margin-bottom:10px;
}

footer .footer-tag{
    color:var(--secondary);
    font-weight:700;
}

footer .creator{
    margin-top:20px;
    color:#666;
    line-height:1.9;
}

@media(max-width:768px){

header{
    padding:20px;
}

.hero{
    padding:70px 20px;
}

.hero h1{
    font-size:52px;
}

.tagline{
    font-size:22px;
}

.section-title{
    font-size:34px;
}

}
</style>
</head>

<body>

<header>
    <div class="nav">

        <div class="brand">

            <div class="brand-icon">
                TRU
            </div>

            <div>
                <div class="brand-name">TRU</div>
                <div class="brand-tag">
                    Trusted Resource & Unified Support
                </div>
            </div>

        </div>

    </div>
</header>

<section class="hero">

    <h1>
        Welcome to <span>TRU</span>
    </h1>

    <div class="tagline">
        Trusted Resource & Unified Support
    </div>

    <p class="hero-description">
        TRU is a modern intelligent platform designed to connect people,
        knowledge, analytics, planning, collaboration, and support into
        one seamless experience. Access trusted information, streamline
        workflows, improve productivity, and make confident decisions
        with a platform built for efficiency and innovation.
    </p>

    <div class="button-group">
        <a href="/chat" class="button">
            Open TRU
        </a>
    </div>

    <div class="creator-card">

        <h2>Elias</h2>

        <div class="role">
            Solutions Analyst | Program Planning
        </div>

        <p>
            Dedicated to creating innovative technology solutions,
            improving user experiences, enhancing operational efficiency,
            and transforming complex challenges into practical and
            meaningful outcomes through strategic planning, intelligent
            design, and digital innovation.
        </p>

    </div>

</section>

<section class="section">

    <h2 class="section-title">
        Platform Features
    </h2>

    <div class="features">

        <div class="feature">
            <h3>Knowledge Center</h3>
            <p>Access trusted documentation, resources, guidance, and organizational knowledge from one location.</p>
        </div>

        <div class="feature">
            <h3>Analytics & Insights</h3>
            <p>Monitor trends, activity, performance indicators, reports, and business intelligence dashboards.</p>
        </div>

        <div class="feature">
            <h3>Program Planning</h3>
            <p>Organize initiatives, manage priorities, track progress, and coordinate programs efficiently.</p>
        </div>

        <div class="feature">
            <h3>Collaboration Hub</h3>
            <p>Improve teamwork, communication, and engagement through a connected digital workspace.</p>
        </div>

        <div class="feature">
            <h3>Document Management</h3>
            <p>Store, organize, search, review, and manage important files securely and efficiently.</p>
        </div>

        <div class="feature">
            <h3>Support Center</h3>
            <p>Submit requests, track issues, and access assistance through a centralized support experience.</p>
        </div>

        <div class="feature">
            <h3>Reports & Dashboards</h3>
            <p>Generate meaningful reports and visualize operational performance through interactive dashboards.</p>
        </div>

        <div class="feature">
            <h3>Smart Search</h3>
            <p>Quickly locate information, policies, documents, and resources with intelligent search capabilities.</p>
        </div>

    </div>

</section>

<footer>

    <h2>TRU</h2>

    <div class="footer-tag">
        Trusted Resource & Unified Support
    </div>

    <div class="creator">
        Created by <strong>Elias</strong><br>
        Solutions Analyst | Program Planning
    </div>

</footer>

</body>
</html>