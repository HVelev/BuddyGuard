using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data.Common;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.ComponentModel;

namespace BuddyGuard.UnitTests
{
    [TestFixture]
    public class MailServiceTests
    {
        private const string recipient = "buddyguardapp@outlook.com";
        private const string subject = "Test";
        private const string body = "Testing";
        private const string host = "smtp-mail.outlook.com";
        private const int port = 587;

        private bool mailSent = false;

        private IRepository repository;

        private MailService service;

        private BuddyguardDbContext context;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<BuddyguardDbContext>()
                .UseInMemoryDatabase("BuddyGuard")
                .Options;

            context = new BuddyguardDbContext(contextOptions);

            context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            this.repository = new Repository(context);
            service = new MailService();
        }

        [Test]
        public void AssertThatCreateEmailGeneratesCorrectEmail()
        {
            var mail = service.CreateMail(recipient, subject, body);

            Assert.Multiple(() =>
            {
                Assert.That(mail.To.First().Address, Is.EqualTo(recipient));
                Assert.That(mail.Subject, Is.EqualTo(subject));
                Assert.That(mail.Body, Is.EqualTo(body));
            });
        }
        
        [Test]
        public void AssertThatGetClientGeneratesCorrectSMTPServer()
        {
            var client = service.GetClient();

            Assert.Multiple(() =>
            {
                Assert.That(client.Host, Is.EqualTo(host));
                Assert.That(client.Port, Is.EqualTo(port));
                Assert.That(client.EnableSsl, Is.True);
            });
        }
        
        [Test]
        public void AssertThatMessageGetsSent()
        {
            var client = service.GetClient();

            var message = service.CreateMail(recipient, subject, body);

            try
            {
                client.Send(message);

                Assert.Pass();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
