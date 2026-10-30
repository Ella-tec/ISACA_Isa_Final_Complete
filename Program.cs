using IsaChatApp.Components;
using IsaChatApp.Services;
using IsaChatApp.Services.Onboarding;
using IsaChatApp.Services.Orchestrator;
using IsaChatApp.Services.Orchestrator.Stages;

using Microsoft.AspNetCore.Authentication.Cookies;

using OrchestratorService =
    IsaChatApp.Services.Orchestrator.Orchestrator;

var builder = WebApplication.CreateBuilder(args);

// ============================================================
// TRU PLATFORM SERVICES
// ============================================================

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient();

// ============================================================
// SHARED PLATFORM SETTINGS
// ============================================================

builder.Services.AddSingleton<WidgetSettings>();
builder.Services.AddSingleton<UsageLogService>();

// ============================================================
// AUTHENTICATION
// ============================================================

builder.Services
    .AddAuthentication(
        CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "TRU.SignIn";
        options.LoginPath = "/sign-in";
        options.AccessDeniedPath = "/sign-in";
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
        options.SlidingExpiration = true;
    });

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddSingleton<KeycloakSignInService>();

// ============================================================
// ONBOARDING SERVICES
// ============================================================

builder.Services.AddSingleton<LeaderTermService>();
builder.Services.AddSingleton<JourneyService>();
builder.Services.AddSingleton<JourneyContextService>();
builder.Services.AddSingleton<ContactService>();
builder.Services.AddSingleton<ProgressService>();
builder.Services.AddSingleton<NotebookService>();
builder.Services.AddSingleton<HandoffService>();

// ============================================================
// PLATFORM MONITORING
// ============================================================

builder.Services.AddHttpClient("keycloak");

builder.Services.AddSingleton<EventLogService>();
builder.Services.AddSingleton<UsageSummaryService>();
builder.Services.AddSingleton<UsageReportService>();
builder.Services.AddSingleton<DevKeysStore>();

builder.Services.AddSingleton<
    IAccessControlAdapter,
    KeycloakAccessControlAdapter>();

// ============================================================
// AI PIPELINE STAGES
// ============================================================

builder.Services.AddSingleton<IStage, AccessControlStage>();
builder.Services.AddSingleton<IStage, TranslationStage>();
builder.Services.AddSingleton<IStage, InputComplianceStage>();
builder.Services.AddSingleton<IStage, DatabaseSearchStage>();
builder.Services.AddSingleton<IStage, KnowledgeGraphStage>();
builder.Services.AddSingleton<IStage, RagStage>();
builder.Services.AddSingleton<IStage, ComplexAiStage>();
builder.Services.AddSingleton<IStage, OutputComplianceStage>();
builder.Services.AddSingleton<IStage, TicketingStage>();

// ============================================================
// AI ORCHESTRATOR
// ============================================================

builder.Services.AddSingleton<OrchestratorService>();

// ============================================================
// BUILD APPLICATION
// ============================================================

var app = builder.Build();

// ============================================================
// HTTP REQUEST PIPELINE
// ============================================================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

// ============================================================
// RAZOR COMPONENTS
// ============================================================

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// ============================================================
// START APPLICATION
// ============================================================

app.Run();