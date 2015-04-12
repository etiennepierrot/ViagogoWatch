using Moq;
using NUnit.Framework;
using ViagogoWatcher.Model.DependancyInjector;
using ViagogoWatcher.Model.Mailings;

namespace ViagogoWatcher.Model.Test
{
    [TestFixture]
    public class MailerServiceTest
    {
        private IMailerService _mailerService;
        private Mock<ISmtpClientFacade> _mock;

        [SetUp]
        public void Setup()
        {
            ConfMailing confMailing = new ConfMailing("no-reply@watcher.com", "admin@watcher.com", new Credential("login", "password"));
            _mock = new Mock<ISmtpClientFacade>();

            _mailerService = new MailerServiceBuilder()
            .WithConfMailing(confMailing)
            .WithStmpClientFacade(_mock.Object)
            .Build();
        }


        [Test]public void
        Stop_Should_Send_Alert_Mail()
        {
            _mailerService.Stop();
            _mock.Verify(x => x.Send("admin@watcher.com", "Service Stoped", string.Empty));

        }
    }
}