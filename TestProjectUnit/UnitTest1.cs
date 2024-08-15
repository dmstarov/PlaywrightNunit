using Microsoft.Playwright;
using Newtonsoft.Json;
using System.IO;


namespace TestProjectUnit
{
    //[Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {
        private Config _config;

        [SetUp]
        public async Task Setup()
        {
            await Page.GotoAsync("https://miaprep.com/#/");

            _config = Config.Load("C:\\courses\\new\\TestProjectUnit\\testdata.json");
        }

        [Test]
        public async Task MioHomepage()
        {
            
            //Assert text to be visible
            await Expect(Page.Locator("#contentcontent__ctl3 div").Filter(new() { HasText = "In addition to our homeschool" }).Nth(3)).ToBeVisibleAsync();
            await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "online high school" })).ToBeVisibleAsync();

            //Navigate by the link on banner
            
            await Page.GetByRole(AriaRole.Link, new() { Name = "online high school" }).ClickAsync();

            //Press application button
            await Page.GetByRole(AriaRole.Link, new() { Name = "Apply Now" }).ClickAsync();

            //Assert correct text is in place
            await Expect(Page.GetByText("MOHS Initial Application")).ToBeVisibleAsync();

            await Page.GetByLabel("Next Navigates to page 2 out of").ClickAsync();

            //Assert header has correct text
            await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Parent Information" })).ToBeVisibleAsync();

            //Assert text box is empty
            await Expect(Page.GetByRole(AriaRole.Textbox, new() { Name = "Name First Name Required" })).ToBeEmptyAsync();

            //Fill in the parent information
            await Page.GetByRole(AriaRole.Textbox, new() { Name = "Name First Name Required" }).ClickAsync();
         
            await Page.GetByRole(AriaRole.Textbox, new() { Name = "Name First Name Required" }).FillAsync(_config.FirstName);
           
            await Page.GetByRole(AriaRole.Textbox, new() { Name = "Name Last Name Required" }).ClickAsync();
           
            await Page.GetByRole(AriaRole.Textbox, new() { Name = "Name Last Name Required" }).FillAsync(_config.FirstName);
            
            await Page.GetByLabel("Email *").ClickAsync();
            
            await Page.GetByLabel("Email *").FillAsync(_config.Email);
            
            await Page.GetByTitle("United States: +").Locator("div").Nth(2).ClickAsync();
            
            await Page.GetByText("Latvia (Latvija)").ClickAsync();
           
            await Page.GetByLabel("Phone *").ClickAsync();
            
            await Page.GetByLabel("Phone *").FillAsync(_config.Phone);
            
            await Page.GetByRole(AriaRole.Combobox, new() { Name = "-Select-" }).Locator("div").ClickAsync();
            
            await Page.GetByRole(AriaRole.Treeitem, new() { Name = "No" }).ClickAsync();
            
            await Page.GetByLabel("What is your preferred start").ClickAsync();
            
            await Page.GetByRole(AriaRole.Link, new() { Name = "31" }).ClickAsync();

            //Go to the student inf page
            await Page.GetByLabel("Next Navigates to page 3 out of").ClickAsync();
            //Assert header text
            await Expect( Page.GetByRole(AriaRole.Heading, new() { Name = "Student Information" }).Locator("b")).ToBeVisibleAsync();
        }
    }
}
