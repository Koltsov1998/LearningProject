using System.Linq;
using LearningProject.Services;
using NUnit.Framework;
using VkApi.Messages;

namespace Tests
{
    public class MemeParsedTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async void Test1()
        {
            TextDetecterForTests textDetecterForTests = new TextDetecterForTests();
            ProgressProcessStorage progressProcessStorage = new ProgressProcessStorage();
            MemeParserService memeParserService = new MemeParserService(textDetecterForTests, progressProcessStorage);


            int publicId = 1;

            var parsedMemes = await memeParserService.ParsePhotos(photos, publicId);

            photos.Response.Items = photos.Response.Items.Take(2).ToArray();

            var parsedMemesArray = parsedMemes.ToArray();

            Assert.AreEqual(3, progressProcessStorage.Progresses[publicId].Done);
            Assert.AreEqual(3, progressProcessStorage.Progresses[publicId].Total);
        }

        private GetPhotosInfos photos = new GetPhotosInfos()
        {
            Response = new Response()
            {
                Count = 3,
                Items = new Item[]
                    {
                        new Item {
                        Id = 457731233,
                        AlbumId = -7,
                        OwnerId = -120254617,
                        UserId = 100,
                        Sizes = new Sizes[] {
                            new Sizes {
                                Type = "m",
                                Url = "https://sun1-99.userapi.com/c857128/v857128872/1180ba/XI7f99K33Bg.jpg",
                                Width = 113,
                                Height = 130
                            },
                            new Sizes {
                                Type = "o",
                                Url = "https://sun1-19.userapi.com/c857128/v857128872/1180bc/i8veqdlILbA.jpg",
                                Width = 130,
                                Height = 149
                            },
                            new Sizes {
                                Type = "p",
                                Url = "https://sun1-85.userapi.com/c857128/v857128872/1180bd/pKPakYNEgj0.jpg",
                                Width = 200,
                                Height = 230
                            },
                            new Sizes {
                                Type = "r",
                                Url = "https://sun1-89.userapi.com/c857128/v857128872/1180bf/7wUoh8EoimY.jpg",
                                Width = 486,
                                Height = 558
                            },
                            new Sizes {
                                Type = "s",
                                Url = "https://sun1-93.userapi.com/c857128/v857128872/1180b9/tNr5PWgjo9o.jpg",
                                Width = 65,
                                Height = 75
                            },
                            new Sizes {
                                Type = "x",
                                Url = "https://sun1-19.userapi.com/c857128/v857128872/1180bb/As8uShGNKB0.jpg",
                                Width = 486,
                                Height = 558
                            }
                        },
                        Text = "",
                        Date = 1584044094,
                    },
                    new Item {
                        Id = 457730960,
                        AlbumId = -7,
                        OwnerId = -120254617,
                        UserId = 100,
                        Sizes = new Sizes[] {
                            new Sizes {
                                Type = "m",
                                Url = "https://sun1-24.userapi.com/c858016/v858016484/1a786e/XzkBaxbgIFM.jpg",
                                Width = 130,
                                Height = 127
                            },
                            new Sizes {
                                Type = "o",
                                Url = "https://sun1-87.userapi.com/c858016/v858016484/1a7870/gJQ5YJ8_6zo.jpg",
                                Width = 130,
                                Height = 127
                            },
                            new Sizes {
                                Type = "p",
                                Url = "https://sun1-24.userapi.com/c858016/v858016484/1a7871/ndwr4eqEcds.jpg",
                                Width = 200,
                                Height = 195
                            },
                            new Sizes {
                                Type = "q",
                                Url = "https://sun1-90.userapi.com/c858016/v858016484/1a7872/170VOEutJpY.jpg",
                                Width = 320,
                                Height = 312
                            },
                            new Sizes {
                                Type = "r",
                                Url = "https://sun1-25.userapi.com/c858016/v858016484/1a7873/2zWqLFsB59k.jpg",
                                Width = 456,
                                Height = 444
                            },
                            new Sizes {
                                Type = "s",
                                Url = "https://sun1-83.userapi.com/c858016/v858016484/1a786d/X1dhy_u_Evc.jpg",
                                Width = 75,
                                Height = 73
                            },
                            new Sizes {
                                Type = "x",
                                Url = "https://sun1-28.userapi.com/c858016/v858016484/1a786f/aQ_0TlZI0dU.jpg",
                                Width = 456,
                                Height = 444
                            }
                        },
                        Text = "",
                        Date = 1584019132,
                    },
                    new Item {
                        Id = 457730962,
                        AlbumId = -7,
                        OwnerId = -120254617,
                        UserId = 100,
                        Sizes = new Sizes[] {
                            new Sizes {
                                Type = "m",
                                Url = "https://sun1-16.userapi.com/c858016/v858016484/1a787c/CKPDKMfowdI.jpg",
                                Width = 111,
                                Height = 130
                            },
                            new Sizes {
                                Type = "o",
                                Url = "https://sun1-86.userapi.com/c858016/v858016484/1a787f/le0Kg8uz9lU.jpg",
                                Width = 130,
                                Height = 152
                            },
                            new Sizes {
                                Type = "p",
                                Url = "https://sun1-21.userapi.com/c858016/v858016484/1a7880/0BB8AQlhF3Y.jpg",
                                Width = 200,
                                Height = 233
                            },
                            new Sizes {
                                Type = "q",
                                Url = "https://sun1-16.userapi.com/c858016/v858016484/1a7881/vNxohdXJATw.jpg",
                                Width = 320,
                                Height = 373
                            },
                            new Sizes {
                                Type = "r",
                                Url = "https://sun1-15.userapi.com/c858016/v858016484/1a7882/z-yPxLqeMnk.jpg",
                                Width = 510,
                                Height = 594
                            },
                            new Sizes {
                                Type = "s",
                                Url = "https://sun1-94.userapi.com/c858016/v858016484/1a787b/hR6-NLEQ2wU.jpg",
                                Width = 64,
                                Height = 75
                            },
                            new Sizes {
                                Type = "x",
                                Url = "https://sun1-84.userapi.com/c858016/v858016484/1a787d/0YoaFzxQWIQ.jpg",
                                Width = 518,
                                Height = 604
                            },
                            new Sizes {
                                Type = "y",
                                Url = "https://sun1-97.userapi.com/c858016/v858016484/1a787e/-4hEmZkM1LI.jpg",
                                Width = 640,
                                Height = 746
                            }
                        },
                        Text = "",
                        Date = 1584019206,
                    },
                    }
            }
        };
    }
}