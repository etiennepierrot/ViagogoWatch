using Moq;
using NUnit.Framework;
using ViagogoWatcher.Model.Connector;
using ViagogoWatcher.Model.Events;
using ViagogoWatcher.Model.Mailings;
using ViagogoWatcher.Model.Subscriptions;


namespace ViagogoWatcher.Model.Test
{
    [TestFixture]
    public class EventCheckerTest
    {
        private EventChecker _eventChecker;
        private Mock<IEventRepository> _mockEventRepository;
        private Mock<IViagogoConnector> _mockConnector;
        private Mock<ISubscriptionRepository> _mockSubscriptionRepository;
        private Event _eventPSG_BARCA;

        [SetUp]
        public void Setup()
        {
            _mockEventRepository = new Mock<IEventRepository>();
            _mockConnector = new Mock<IViagogoConnector>();
            _mockSubscriptionRepository = new Mock<ISubscriptionRepository>();

            _eventChecker = new EventChecker(_mockEventRepository.Object, _mockConnector.Object, _mockSubscriptionRepository.Object, new Mock<IMailerService>().Object);

            _eventPSG_BARCA = new Event("http://viagogo.com/PSG-BARCA", "PSG-BARCA");
        }

        [Test]public void
        Check_Should_Get_All_The_Event_To_Check()
        {
            _eventChecker.Check();
            _mockEventRepository.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]public void
        CheckEvent_Should_GetPricing()
        {
            _eventChecker.CheckEvent(_eventPSG_BARCA);
            _mockConnector.Verify(x => x.GetProduct("http://viagogo.com/PSG-BARCA"), Times.Once);
        }

        [Test]public void
        CheckEvent_Shoud_Get_The_Subscritions_Of_The_Event()
        {
            _eventChecker.CheckEvent(_eventPSG_BARCA);
            _mockSubscriptionRepository.Verify(x => x.GetSubscriptionsByEvent(_eventPSG_BARCA.Code));
        }

        [Test]public void
        CheckEvent_Shoud_Send_Alert_If_Subscrition_Has_A_Match()
        {
            _eventChecker.CheckEvent(_eventPSG_BARCA);
            _mockSubscriptionRepository.Verify(x => x.GetSubscriptionsByEvent(_eventPSG_BARCA.Code));
        }



    }
}