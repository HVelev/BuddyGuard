using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Data.Models;
using BuddyGuard.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Services
{
    public class BuddiesService : IBuddiesService
    {
        private BuddyguardDbContext db;

        public BuddiesService(BuddyguardDbContext db)
        {
            this.db = db;
        }

        public void Upload(string comment, Stream file)
        {
            if (file != null)
            {
                using (BinaryReader br = new BinaryReader(file))
                {
                    var buddy = new Buddy
                    {
                        Comment = comment,
                        UserId = "1cda1014-36e7-45d5-a0aa-328f0ddaf90c",
                        PublishedOn = DateTime.Now,
                        Image = br.ReadBytes((int)file.Length)
                    };

                    db.Buddies.Add(buddy);
                }

                db.SaveChanges();
            }
        }

        public BuddyDTO[] GetImages()
        {
            var buddies = (from buddy in db.Buddies
                          orderby buddy.PublishedOn
                          select new BuddyDTO
                          {
                              Username = "someone",
                              Image = buddy.Image,
                              Comment = buddy.Comment,
                          }).ToArray();

            return buddies;
        }
    }
}
