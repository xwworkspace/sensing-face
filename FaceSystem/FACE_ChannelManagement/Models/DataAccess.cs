namespace FACE_ChannelManagement.Models
{
    public class DataAccess
    {
        #region GetFamilyTree

        public static Channel GetFamilyTree()
        {
            // In a real app this method would access a database.
            return new Channel
            {
                Name = "ChannelGroup1",
                Children =
                {
                    new Channel
                    {
                        Name="Group01",
                        Children=
                        {
                            new Channel
                            {
                                Name="Group0101",
                                Children=
                                {
                                    new Channel
                                    {
                                        Name="Channel1010",
                                    }
                                }
                            },
                            new Channel
                            {
                                Name="Group0101",
                                Children=
                                {
                                    new Channel
                                    {
                                        Name="Channel101",
                                    },
                                    new Channel
                                    {
                                        Name="Channel102",
                                    },
                                    new Channel
                                    {
                                        Name="Channel103",
                                    }
                                }
                            }
                        }
                    },
                    new Channel
                    {
                        Name="ChannelGroup2",
                        Children=
                        {
                            new Channel
                            {
                                Name="Group02",
                                Children=
                                {
                                    new Channel
                                    {
                                        Name="Channel001",
                                    }
                                }
                            },
                            new Channel
                            {
                                Name="Group03",
                                Children=
                                {
                                    new Channel
                                    {
                                        Name="Channel201",
                                    },
                                    new Channel
                                    {
                                        Name="Channel202",
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

        #endregion // GetFamilyTree
    }
}
