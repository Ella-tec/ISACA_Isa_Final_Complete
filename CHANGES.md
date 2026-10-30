<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>TRU</title>

<link href="https://fonts.googleapis.com/css2?family=Roboto:wght@300;400;500;700&display=swap" rel="stylesheet">

<style>
:root{
    --tru-blue:#0A2A66;
    --tru-green:#14B89A;
    --tru-light:#F7FAFC;
    --tru-gray:#6B7280;
    --tru-border:#E5E7EB;
}

*{
    margin:0;
    padding:0;
    box-sizing:border-box;
}

body{
    font-family:'Roboto',sans-serif;
    background:#ffffff;
    color:#1f2937;
}

.header{
    padding:20px 50px;
    display:flex;
    justify-content:space-between;
    align-items:center;
    border-bottom:1px solid var(--tru-border);
}

.logo{
    display:flex;
    align-items:center;
    gap:15px;
}

.logo-circle{
    width:48px;
    height:48px;
    border-radius:50%;
    background:linear-gradient(135deg,var(--tru-blue),var(--tru-green));
    display:flex;
    justify-content:center;
    align-items:center;
    color:white;
    font-weight:700;
    font-size:14px;
}

.logo-text h2{
    color:var(--tru-blue);
    font-size:28px;
}

.logo-text p{
    color:var(--tru-green);
    font-size:14px;
}

.hero{
    max-width:1200px;
    margin:auto;
    padding:100px 30px;
    text-align:center;
}

.hero h1{
    font-size:72px;
    color:var(--tru-blue);
    margin-bottom:15px;
    font-weight:700;
}

.hero .tagline{
    color:var(--tru-green);
    font-size:28px;
    font-weight:600;
    margin-bottom:30px;
}

.hero p{
    max-width:850px;
    margin:auto;
    color:#555;
    line-height:1.9;
    font-size:20px;
}

.author-card{
    max-width:700px;
    margin:60px auto;
    padding:35px;
    border-radius:24px;
    background:var(--tru-light);
    border:1px solid var(--tru-border);
    box-shadow:0 10px 30px rgba(0,0,0,.05);
}

.author-card h2{
    color:var(--tru-blue);
    margin-bottom:10px;
}

.author-card .role{
    color:var(--tru-green);
    font-size:20px;
    font-weight:600;
    margin-bottom:20px;
}

.features{
    max-width:1200px;
    margin:auto;
    padding:20px 30px 80px;
}

.section-title{
    text-align:center;
    color:var(--tru-blue);
    font-size:42px;
    margin-bottom:50px;
}

.grid{
    display:grid;
    grid-template-columns:repeat(auto-fit,minmax(260px,1fr));
    gap:25px;
}

.card{
    padding:25px;
    border-radius:18px;
    border:1px solid var(--tru-border);
    transition:.3s;
    background:white;
}

.card:hover{
    transform:translateY(-5px);
    box-shadow:0 10px 25px rgba(0,0,0,.08);
}

.card h3{
    color:var(--tru-blue);
    margin-bottom:12px;
}

.card p{
    color:#555;
    line-height:1.7;
}

.footer{
    padding:40px;
    text-align:center;
    background:#fafafa;
    border-top:1px solid var(--tru-border);
}

.footer h3{
    color:var(--tru-blue);
    margin-bottom:10px;
}

.footer p{
    color:var(--tru-gray);
    line-height:1.8;
}

@media(max-width:768px){

.hero h1{
    font-size:50px;
}

.hero .tagline{
    font-size:22px;
}

.header{
    padding:20px;
}

}
</style>
</head>

<body>

<header class="header">

    <div class="logo">

        <div class="logo-circle">
            TRU
        </div>

        <div class="logo-text">
            <h2>TRU</h2>
            <p>Trusted Resource & Unified Support</p>
        </div>

    </div>

</header>

<section class="hero">

    <h1>TRU</h1>

    <div class="tagline">
        Trusted Resource & Unified Support
    </div>

    <p>
        A modern intelligent platform designed to simplify access to information,
        resources, collaboration, analytics, and support through one unified
        experience. TRU empowers users with trusted guidance, streamlined
        workflows, and powerful tools to improve productivity and decision-making.
    </p>

    <div class="author-card">

        <h2>Elias</h2>

        <div class="role">
            Solutions Analyst | Program Planning
        </div>

        <p>
            Passionate about creating innovative solutions, enhancing digital
            experiences, improving operational efficiency, and transforming
            complex challenges into meaningful outcomes through technology,
            planning, and strategic thinking.
        </p>

    </div>

</section>

<section class="features">

    <h2 class="section-title">
        Platform Features
    </h2>

    <div class="grid">

        <div class="card">
            <h3>Knowledge Center</h3>
            <p>Access trusted information, guidance, and organizational resources from a centralized location.</p>
        </div>

        <div class="card">
            <h3>Analytics & Insights</h3>
            <p>Monitor performance, trends, activity metrics, and business intelligence dashboards.</p>
        </div>

        <div class="card">
            <h3>Project Planning</h3>
            <p>Manage initiatives, organize priorities, and track program activities efficiently.</p>
        </div>

        <div class="card">
            <h3>Support Services</h3>
            <p>Receive assistance, track requests, and connect with the right resources quickly.</p>
        </div>

        <div class="card">
            <h3>Document Management</h3>
            <p>Store, organize, search, and manage important files and resources.</p>
        </div>

        <div class="card">
            <h3>Collaboration Hub</h3>
            <p>Improve communication and teamwork through a connected digital workspace.</p>
        </div>

    </div>

</section>

<footer class="footer">

    <h3>TRU</h3>

    <p>
        Trusted Resource & Unified Support
    </p>

    <p>
        Created by <strong>Elias</strong><br>
        Solutions Analyst | Program Planning
    </p>

</footer>

</body>
</html>