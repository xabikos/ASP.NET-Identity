<h1>New ASP.NET Identity Custom Implementation</h1>

<p>This is an example of custom implementation of new ASP.NET Identity framework which included in ASP.NET  
with Visual Studio 2013 RC.</p>
  

<h2>Requirements</h2>
<ul>
    <li>.NET Framework 4.5.1</li>
    <li>Visual Studio 2013 RC</li>
</ul>


<h2>Project structure</h2>

<p>The solution consists of three projects.</p>

<h4>Asp.Identity</h4>

<p>Initially is the Asp.Identity project that includes all the implementation of core interfaces and has only a dependency
on Asp.Identity.Core. There is no dependency on Entity Framework or any other library so it could be used as based project
for other solutions, for example in combination with NHibernate. Furthermore the Entities don't have any data access specific code or attributes.</p>

<p>The most important note here is the UserBase class that adds some extra properties 
	just to show how we can extend the basic interfaces.</p>

<h4>Asp.Identity.EntityFramework</h4>

<p>Then is the Asp.Identity.EntityFramework project that includes a custom implementation of IIdentityStore interface through Entity Framework.
	Moreover it includes the entities configuration files so to store these in different database tables than the default.</p>

<p>The class IdentityContext is the class that used for all the database interaction and includes code validation for checking
	duplicate Email which is a custom property.</p>

<pre>
protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
{
    if(entityEntry != null && entityEntry.State == EntityState.Added)
    {
        // Validation for duplicate email
        UserBase user = entityEntry.Entity as UserBase;
        if(user != null)
        {
            if(Users.Any(u => u.Email.ToUpper() == user.Email.ToUpper()))
            {
                return new DbEntityValidationResult(entityEntry, new List<DbValidationError>())
                {
                    ValidationErrors =
                    {
                        new DbValidationError("User", string.Format(CultureInfo.CurrentCulture, "Duplicate Email. Email: {0}", user.Email))
                    }
                };
            }
        }
    }
    return base.ValidateEntity(entityEntry, items);
}
</pre>

<h4>Asp.Identity.EntityFramework.Web</h4>

<p>At last is the web project that uses the previous ones during User authentication and authorization.</p>

<p>It is the basic ASP.NET MVC project VS2013 RC offers and the only change is in the Account Controller class.</p>

<p>More specifically in the constructor of the controller we initialize the AuthenticationIdentityManager 
	with the custom implementation of IIdentityStore</p>

<pre>
public AccountController() 
{
    var identityDbContext = new IdentityContext("DefaultConnection");
    IdentityManager = new AuthenticationIdentityManager(new IdentityStore(identityDbContext));
}
</pre>

<p>
	Additionaly there are some changes in RegisterViewModel class that includes the Email field which is required.
	It is also available the log in functionality through Google.
</p>