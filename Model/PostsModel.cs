﻿namespace EdgeApi.Model
{
    public class PostsModel
    {
        public int userId { get; set; }
        public int? id { get; set; }
        public string title { get; set; }
        public string body { get; set; }

    }

    public class PostsInsModel
    {
        public int userId { get; set; }
        public string title { get; set; }
        public string body { get; set; }

    }
}
