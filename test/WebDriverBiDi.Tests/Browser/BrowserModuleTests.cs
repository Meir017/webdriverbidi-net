namespace WebDriverBiDi.Browser;

using TestUtilities;

[TestFixture]
public class BrowserModuleTests
{
    [Test]
    public async Task TestExecuteCloseCommand()
    {
        TestConnection connection = new();
        connection.DataSendComplete += async (sender, e) =>
        {
            string responseJson = @"{ ""type"": ""success"", ""id"": " + e.SentCommandId + @", ""result"": { } }";
            await connection.RaiseDataReceivedEventAsync(responseJson);
        };

        BiDiDriver driver = new(TimeSpan.FromMilliseconds(500), new(connection));
        await driver.StartAsync("ws:localhost");
        BrowserModule module = new(driver);

        Task<EmptyResult> task = module.CloseAsync(new CloseCommandParameters());
        task.Wait(TimeSpan.FromSeconds(1));
        EmptyResult result = task.Result;

        Assert.That(result, Is.Not.Null);
    }
    
    [Test]
    public async Task TestExecuteCloseCommandWithNoArgument()
    {
        TestConnection connection = new();
        connection.DataSendComplete += async (sender, e) =>
        {
            string responseJson = @"{ ""type"": ""success"", ""id"": " + e.SentCommandId + @", ""result"": { } }";
            await connection.RaiseDataReceivedEventAsync(responseJson);
        };

        BiDiDriver driver = new(TimeSpan.FromMilliseconds(500), new(connection));
        await driver.StartAsync("ws:localhost");
        BrowserModule module = new(driver);

        Task<EmptyResult> task = module.CloseAsync();
        task.Wait(TimeSpan.FromSeconds(1));
        EmptyResult result = task.Result;

        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public async Task TestExecuteCreateUserContextCommand()
    {
        TestConnection connection = new();
        connection.DataSendComplete += async (sender, e) =>
        {
            string responseJson = @"{ ""type"": ""success"", ""id"": " + e.SentCommandId + @", ""result"": { ""userContext"": ""myUserContextId"" } }";
            await connection.RaiseDataReceivedEventAsync(responseJson);
        };

        BiDiDriver driver = new(TimeSpan.FromMilliseconds(500), new(connection));
        await driver.StartAsync("ws:localhost");
        BrowserModule module = new(driver);

        Task<CreateUserContextCommandResult> task = module.CreateUserContextAsync(new CreateUserContextCommandParameters());
        task.Wait(TimeSpan.FromSeconds(1));
        CreateUserContextCommandResult result = task.Result;

        Assert.That(result, Is.Not.Null);
        Assert.That(result.UserContextId, Is.EqualTo("myUserContextId"));
    }

    [Test]
    public async Task TestExecuteCreateUserContextCommandWithNoArgument()
    {
        TestConnection connection = new();
        connection.DataSendComplete += async (sender, e) =>
        {
            string responseJson = @"{ ""type"": ""success"", ""id"": " + e.SentCommandId + @", ""result"": { ""userContext"": ""myUserContextId"" } }";
            await connection.RaiseDataReceivedEventAsync(responseJson);
        };

        BiDiDriver driver = new(TimeSpan.FromMilliseconds(500), new(connection));
        await driver.StartAsync("ws:localhost");
        BrowserModule module = new(driver);

        Task<CreateUserContextCommandResult> task = module.CreateUserContextAsync();
        task.Wait(TimeSpan.FromSeconds(1));
        CreateUserContextCommandResult result = task.Result;

        Assert.That(result, Is.Not.Null);
        Assert.That(result.UserContextId, Is.EqualTo("myUserContextId"));
    }

    [Test]
    public async Task TestExecuteGetUserContextsCommand()
    {
        TestConnection connection = new();
        connection.DataSendComplete += async (sender, e) =>
        {
            string responseJson = @"{ ""type"": ""success"", ""id"": " + e.SentCommandId + @", ""result"": { ""userContexts"": [ { ""userContext"": ""default"" }, { ""userContext"": ""myUserContextId"" } ] } }";
            await connection.RaiseDataReceivedEventAsync(responseJson);
        };

        BiDiDriver driver = new(TimeSpan.FromMilliseconds(500), new(connection));
        await driver.StartAsync("ws:localhost");
        BrowserModule module = new(driver);

        Task<GetUserContextsCommandResult> task = module.GetUserContextsAsync(new GetUserContextsCommandParameters());
        task.Wait(TimeSpan.FromSeconds(1));
        GetUserContextsCommandResult result = task.Result;

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.UserContexts, Has.Count.EqualTo(2));
            Assert.That(result.UserContexts[0].UserContextId, Is.EqualTo("default"));
            Assert.That(result.UserContexts[1].UserContextId, Is.EqualTo("myUserContextId"));
        });

    }

    [Test]
    public async Task TestExecuteGetUserContextsCommandWithNoArgument()
    {
        TestConnection connection = new();
        connection.DataSendComplete += async (sender, e) =>
        {
            string responseJson = @"{ ""type"": ""success"", ""id"": " + e.SentCommandId + @", ""result"": { ""userContexts"": [ { ""userContext"": ""default"" }, { ""userContext"": ""myUserContextId"" } ] } }";
            await connection.RaiseDataReceivedEventAsync(responseJson);
        };

        BiDiDriver driver = new(TimeSpan.FromMilliseconds(500), new(connection));
        await driver.StartAsync("ws:localhost");
        BrowserModule module = new(driver);

        Task<GetUserContextsCommandResult> task = module.GetUserContextsAsync();
        task.Wait(TimeSpan.FromSeconds(1));
        GetUserContextsCommandResult result = task.Result;

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.UserContexts, Has.Count.EqualTo(2));
            Assert.That(result.UserContexts[0].UserContextId, Is.EqualTo("default"));
            Assert.That(result.UserContexts[1].UserContextId, Is.EqualTo("myUserContextId"));
        });

    }

    [Test]
    public async Task TestExecuteRemoveUserContextCommand()
    {
        TestConnection connection = new();
        connection.DataSendComplete += async (sender, e) =>
        {
            string responseJson = @"{ ""type"": ""success"", ""id"": " + e.SentCommandId + @", ""result"": { } }";
            await connection.RaiseDataReceivedEventAsync(responseJson);
        };

        BiDiDriver driver = new(TimeSpan.FromMilliseconds(500), new(connection));
        await driver.StartAsync("ws:localhost");
        BrowserModule module = new(driver);

        Task<EmptyResult> task = module.RemoveUserContextAsync(new RemoveUserContextCommandParameters("myUserContextId"));
        task.Wait(TimeSpan.FromSeconds(1));
        EmptyResult result = task.Result;

        Assert.That(result, Is.Not.Null);
    }
}
