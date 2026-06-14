const repositoryUrl =
  "https://github.com/hristianivanov/ITJob-Finder-ASP.NET-MVC";

const audiences = [
  {
    icon: "01",
    title: "For candidates",
    description:
      "Discover relevant roles, filter job offers, save opportunities, and track submitted applications.",
    features: ["Job discovery", "Saved offers", "Application tracking"],
  },
  {
    icon: "02",
    title: "For companies",
    description:
      "Publish and manage job offers, review candidates, and maintain a detailed company profile.",
    features: ["Offer management", "Candidate review", "Company profiles"],
  },
  {
    icon: "03",
    title: "For admins",
    description:
      "Manage platform content, technologies, developments, and company visibility from focused admin tools.",
    features: ["Content management", "Platform oversight", "Role protection"],
  },
];

const screenshots = [
  {
    path: "/placeholders/job-discovery.svg",
    title: "Job discovery",
    description: "Search, filters, salary details, and technology tags.",
  },
  {
    path: "/placeholders/company-profile.svg",
    title: "Company profiles",
    description: "Company information, active offers, and technology stack.",
  },
  {
    path: "/placeholders/company-dashboard.svg",
    title: "Company dashboard",
    description: "Job-offer management and candidate review workflows.",
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

const improvements = [
  {
    value: ".NET 8",
    title: "Modern runtime",
    description: "Migrated from .NET 6 with matching framework dependencies.",
  },
  {
    value: "177",
    title: "Automated tests",
    description: "Service, ownership, authorization, and invalid-input coverage.",
  },
  {
    value: "CI",
    title: "Build confidence",
    description: "GitHub Actions restores, builds, and tests every change.",
  },
  {
    value: "Secrets",
    title: "Safer configuration",
    description: "Local credentials moved to ASP.NET Core user-secrets.",
  },
  {
    value: "Ownership",
    title: "Defense in depth",
    description: "Company mutations enforce ownership inside the service layer.",
  },
  {
    value: "EF Core",
    title: "Query optimization",
    description: "Read-only tracking removed and queries kept server-side.",
  },
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
          <a href="#features">Features</a>
          <a href="#gallery">Gallery</a>
          <a href="#quality">Quality</a>
          <a className="nav-cta" href={repositoryUrl} target="_blank" rel="noreferrer">
            GitHub
          </a>
        </nav>
      </header>

      <main id="top">
        <section className="hero">
          <div className="hero-copy">
            <p className="eyebrow">ASP.NET MVC graduation project</p>
            <h1>A focused job platform built for candidates and companies.</h1>
            <p className="hero-text">
              DevHunter connects IT professionals with employers through job
              discovery, company tools, candidate management, and role-based
              administration.
            </p>
            <div className="hero-actions">
              <a className="button primary" href="#gallery">
                Explore the project
              </a>
              <a className="button secondary" href={repositoryUrl} target="_blank" rel="noreferrer">
                View source on GitHub
              </a>
            </div>
            <div className="showcase-note">
              <strong>Static showcase.</strong> Full ASP.NET MVC app runs locally.
            </div>
          </div>
          <div className="hero-panel" aria-label="Project highlights">
            <div className="panel-top">
              <span className="status-dot" />
              Portfolio-ready engineering pass
            </div>
            <div className="metric-grid">
              <div><strong>3</strong><span>User roles</span></div>
              <div><strong>177</strong><span>Tests</span></div>
              <div><strong>.NET 8</strong><span>Runtime</span></div>
              <div><strong>CI</strong><span>Automated</span></div>
            </div>
            <div className="architecture">
              <span>Presentation</span>
              <span>Services</span>
              <span>EF Core</span>
              <span>SQL Server</span>
            </div>
          </div>
        </section>

        <section id="features" className="section">
          <SectionHeading
            eyebrow="Product scope"
            title="Purpose-built experiences for each role"
            text="The application keeps candidate, company, and administrative workflows distinct while sharing a consistent service and data layer."
          />
          <div className="feature-grid">
            {audiences.map((audience) => (
              <article className="feature-card" key={audience.title}>
                <span className="card-number">{audience.icon}</span>
                <h3>{audience.title}</h3>
                <p>{audience.description}</p>
                <ul>
                  {audience.features.map((feature) => <li key={feature}>{feature}</li>)}
                </ul>
              </article>
            ))}
          </div>
        </section>

        <section id="gallery" className="section gallery-section">
          <SectionHeading
            eyebrow="Product gallery"
            title="A quick look at the core experience"
            text="Replace these placeholder images with polished screenshots before deploying the showcase."
          />
          <div className="gallery-grid">
            {screenshots.map((screenshot) => (
              <figure className="screenshot-card" key={screenshot.title}>
                <img src={screenshot.path} alt={`${screenshot.title} placeholder`} />
                <figcaption>
                  <strong>{screenshot.title}</strong>
                  <span>{screenshot.description}</span>
                </figcaption>
              </figure>
            ))}
          </div>
        </section>

        <section className="section video-section">
          <div>
            <p className="eyebrow">Demo video</p>
            <h2>Walk through the complete workflow</h2>
            <p>
              Add a short recruiter-focused demo at
              <code>/public/media/devhunter-demo.mp4</code>.
            </p>
          </div>
          <video controls preload="metadata" poster="/placeholders/demo-video-poster.svg">
            <source src="/media/devhunter-demo.mp4" type="video/mp4" />
            Your browser does not support embedded video.
          </video>
        </section>

        <section className="section">
          <SectionHeading
            eyebrow="Technology"
            title="A practical full-stack .NET foundation"
            text="The project uses established tools that map directly to junior .NET developer responsibilities."
          />
          <div className="stack-list">
            {stack.map((technology) => <span key={technology}>{technology}</span>)}
          </div>
        </section>

        <section id="quality" className="section quality-section">
          <SectionHeading
            eyebrow="Engineering quality"
            title="Refactored beyond the original graduation scope"
            text="The later quality pass focused on security, maintainability, performance, testing, and reliable delivery."
          />
          <div className="quality-grid">
            {improvements.map((item) => (
              <article key={item.title}>
                <strong>{item.value}</strong>
                <h3>{item.title}</h3>
                <p>{item.description}</p>
              </article>
            ))}
          </div>
        </section>

        <section className="cta-section">
          <div>
            <p className="eyebrow">Explore the implementation</p>
            <h2>Review DevHunter on GitHub</h2>
            <p>
              See the MVC architecture, service layer, tests, CI workflow, and
              focused refactoring history.
            </p>
          </div>
          <a className="button primary" href={repositoryUrl} target="_blank" rel="noreferrer">
            Open GitHub repository
          </a>
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

