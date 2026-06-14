const repositoryUrl =
  "https://github.com/hristianivanov/ITJob-Finder-ASP.NET-MVC";

const metrics = [
  { value: ".NET 8", label: "Modernized runtime" },
  { value: "177", label: "Automated tests" },
  { value: "CI ready", label: "Build and test workflow" },
  { value: "User-secrets", label: "Local secret management" },
  { value: "Ownership", label: "Service-level checks" },
  { value: "7.9 MB", label: "Static asset cleanup" },
];

const audiences = [
  {
    number: "01",
    title: "Candidates",
    description:
      "Find relevant IT roles, save opportunities, and manage applications from one focused experience.",
    features: ["Discover jobs", "Filter offers", "Track applications"],
  },
  {
    number: "02",
    title: "Companies",
    description:
      "Publish job offers, review applicants, and maintain a visible employer profile.",
    features: ["Manage offers", "Review candidates", "Own company content"],
  },
  {
    number: "03",
    title: "Admins",
    description:
      "Moderate platform content and manage the supporting data that keeps listings useful.",
    features: ["Manage content", "Control technologies", "Protect admin tools"],
  },
];

const screenshots = [
  {
    path: "/media/screenshots/home.png",
    title: "Home",
    description: "Recruitment-focused landing page and development categories.",
  },
  {
    path: "/media/screenshots/job-list.png",
    title: "Job discovery",
    description: "Seeded job offers, technology tags, locations, and search.",
  },
  {
    path: "/media/screenshots/job-details.png",
    title: "Job details",
    description: "Requirements, company context, and application entry point.",
  },
  {
    path: "/media/screenshots/candidate-apply.png",
    title: "Candidate application",
    description: "Authenticated application workflow with document upload.",
  },
  {
    path: "/media/screenshots/company-dashboard.png",
    title: "Company dashboard",
    description: "Owned job offer management for authenticated companies.",
  },
  {
    path: "/media/screenshots/company-details.png",
    title: "Company details",
    description: "Employer profile, business information, and active offers.",
  },
  {
    path: "/media/screenshots/admin-panel.png",
    title: "Admin panel",
    description: "Role-protected platform management shortcuts.",
  },
];

const workflows = [
  {
    role: "Candidate flow",
    steps: ["Create profile", "Discover and filter jobs", "Save or apply", "Track applications"],
  },
  {
    role: "Company flow",
    steps: ["Register company", "Build employer profile", "Publish offers", "Review applicants"],
  },
  {
    role: "Admin flow",
    steps: ["Authenticate as admin", "Review platform data", "Manage content", "Maintain quality"],
  },
];

const improvements = [
  {
    title: "Security and authorization",
    text: "Moved local credentials to user-secrets and enforced ownership inside mutation services.",
  },
  {
    title: "Maintainability",
    text: "Reduced duplicated mappings, split long service methods, and centralized repeated messages.",
  },
  {
    title: "Data access",
    text: "Kept pagination server-side, added AsNoTracking, and removed unsafe string Guid comparisons.",
  },
  {
    title: "Delivery confidence",
    text: "Migrated to .NET 8, expanded the test suite to 177 tests, and aligned CI with the runtime.",
  },
];

const stack = [
  "ASP.NET Core MVC",
  ".NET 8",
  "Entity Framework Core",
  "SQL Server",
  "ASP.NET Core Identity",
  "Cloudinary",
  "MailKit",
  "NUnit",
  "GitHub Actions",
];

function SectionHeading({
  eyebrow,
  title,
  text,
}: {
  eyebrow: string;
  title: string;
  text: string;
}) {
  return (
    <div className="section-heading">
      <p className="eyebrow">{eyebrow}</p>
      <h2>{title}</h2>
      <p>{text}</p>
    </div>
  );
}

function App() {
  return (
    <>
      <header className="site-header">
        <a className="brand" href="#top" aria-label="DevHunter showcase home">
          <span>DH</span>
          DevHunter
        </a>
        <nav aria-label="Primary navigation">
          <a href="#product">Product</a>
          <a href="#architecture">Architecture</a>
          <a href="#quality">Quality</a>
          <a className="nav-cta" href={repositoryUrl} target="_blank" rel="noreferrer">
            GitHub
          </a>
        </nav>
      </header>

      <main id="top">
        <section className="hero">
          <div className="hero-copy">
            <p className="eyebrow">ASP.NET Core MVC portfolio project</p>
            <h1>IT jobs. Better matched.</h1>
            <p className="hero-text">
              A role-based recruitment platform for candidates, companies, and administrators.
            </p>
            <div className="hero-actions">
              <a className="button primary" href="#demo">Watch Demo</a>
              <a className="button secondary" href={repositoryUrl} target="_blank" rel="noreferrer">
                View GitHub
              </a>
            </div>
            <div className="showcase-note">
              <strong>Static showcase.</strong> Full ASP.NET MVC app runs locally.
            </div>
          </div>
          <aside className="hero-panel" aria-label="DevHunter product preview">
            <div className="panel-top">
              <span className="status-dot" />
              DevHunter product preview
            </div>
            <img
              className="hero-preview"
              src="/media/screenshots/home.png"
              alt="DevHunter home page preview"
            />
          </aside>
        </section>

        <section className="metrics-strip" aria-label="Project metrics">
          {metrics.map((metric) => (
            <div key={metric.label}>
              <strong>{metric.value}</strong>
              <span>{metric.label}</span>
            </div>
          ))}
        </section>

        <section id="product" className="section">
          <SectionHeading
            eyebrow="Product scope"
            title="One platform, three focused experiences"
            text="Each role gets the tools it needs, backed by shared service and data layers."
          />
          <div className="feature-grid">
            {audiences.map((audience) => (
              <article className="feature-card" key={audience.title}>
                <span className="card-number">{audience.number}</span>
                <h3>{audience.title}</h3>
                <p>{audience.description}</p>
                <ul>
                  {audience.features.map((feature) => <li key={feature}>{feature}</li>)}
                </ul>
              </article>
            ))}
          </div>
        </section>

        <section id="architecture" className="section architecture-section">
          <SectionHeading
            eyebrow="Architecture"
            title="A clear path from request to data"
            text="A conventional layered structure keeps controllers focused and business rules testable."
          />
          <div className="architecture-flow" aria-label="Application architecture flow">
            {["ASP.NET MVC", "Services", "EF Core", "SQL Server", "Identity"].map((item, index) => (
              <div className="architecture-node" key={item}>
                <span>{String(index + 1).padStart(2, "0")}</span>
                <strong>{item}</strong>
              </div>
            ))}
          </div>
        </section>

        <section className="section">
          <SectionHeading
            eyebrow="Role-based workflows"
            title="Complete journeys, not isolated screens"
            text="The application supports the core actions each platform participant needs to complete."
          />
          <div className="workflow-grid">
            {workflows.map((workflow) => (
              <article className="workflow-card" key={workflow.role}>
                <h3>{workflow.role}</h3>
                <ol>
                  {workflow.steps.map((step) => <li key={step}>{step}</li>)}
                </ol>
              </article>
            ))}
          </div>
        </section>

        <section className="section before-after-section">
          <SectionHeading
            eyebrow="Before vs after"
            title="From graduation submission to portfolio-ready codebase"
            text="The product behavior stayed intact while the engineering foundation became safer and easier to maintain."
          />
          <div className="comparison-grid">
            <article>
              <span className="comparison-label">Before</span>
              <h3>Working graduation project</h3>
              <ul>
                <li>.NET 6 application baseline</li>
                <li>Credentials stored in local configuration</li>
                <li>Authorization concentrated in controllers</li>
                <li>Repeated mappings and tracked read queries</li>
              </ul>
            </article>
            <article className="after-card">
              <span className="comparison-label">After</span>
              <h3>Recruiter-ready engineering story</h3>
              <ul>
                <li>.NET 8 runtime and aligned CI</li>
                <li>User-secrets and safe configuration placeholders</li>
                <li>Service-level ownership enforcement</li>
                <li>177 tests and optimized EF Core queries</li>
              </ul>
            </article>
          </div>
        </section>

        <section id="quality" className="section quality-section">
          <SectionHeading
            eyebrow="What I improved after graduation"
            title="Deliberate improvements with practical impact"
            text="The refactor focused on the areas that matter when maintaining a production-style .NET application."
          />
          <div className="quality-grid">
            {improvements.map((item, index) => (
              <article key={item.title}>
                <span>0{index + 1}</span>
                <h3>{item.title}</h3>
                <p>{item.text}</p>
              </article>
            ))}
          </div>
        </section>

        <section className="section gallery-section">
          <SectionHeading
            eyebrow="Product gallery"
            title="The core DevHunter experience"
            text="Real screens captured from the locally running ASP.NET MVC application with seeded demo data."
          />
          <div className="gallery-grid">
            {screenshots.map((screenshot) => (
              <figure className="screenshot-card" key={screenshot.title}>
                <div className="media-frame">
                  <img src={screenshot.path} alt={`${screenshot.title} screen from DevHunter`} />
                </div>
                <figcaption>
                  <strong>{screenshot.title}</strong>
                  <span>{screenshot.description}</span>
                </figcaption>
              </figure>
            ))}
          </div>
        </section>

        <section id="demo" className="section video-section">
          <div>
            <p className="eyebrow">Demo video</p>
            <h2>See the complete workflow</h2>
            <p>Watch a concise walkthrough of the candidate, company, and administrator journeys.</p>
            <a className="text-link" href={repositoryUrl} target="_blank" rel="noreferrer">
              Explore the implementation on GitHub →
            </a>
          </div>
          <video
            className="demo-video"
            controls
            preload="metadata"
            poster="/media/screenshots/home.png"
          >
            <source src="/media/devhunter-demo.mp4" type="video/mp4" />
            Your browser does not support the DevHunter demo video.
          </video>
        </section>

        <section className="section">
          <SectionHeading
            eyebrow="Technology"
            title="A practical full-stack .NET foundation"
            text="Established tools that map directly to day-to-day junior .NET developer responsibilities."
          />
          <div className="stack-list">
            {stack.map((technology) => <span key={technology}>{technology}</span>)}
          </div>
        </section>

        <section className="cta-section">
          <div>
            <p className="eyebrow">Review the code</p>
            <h2>Explore how DevHunter was built and improved.</h2>
            <p>See the MVC architecture, service layer, tests, authorization checks, and focused refactoring history.</p>
          </div>
          <div className="cta-actions">
            <a className="button primary" href={repositoryUrl} target="_blank" rel="noreferrer">
              GitHub Repository
            </a>
            <a className="button secondary" href="#quality">Code Quality Highlights</a>
          </div>
        </section>
      </main>

      <footer>
        <span>DevHunter project showcase</span>
        <span>Static showcase. Full ASP.NET MVC app runs locally.</span>
      </footer>
    </>
  );
}

export default App;
