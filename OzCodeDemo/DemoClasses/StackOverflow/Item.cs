namespace OzCodeDemo.DemoClasses.StackOverflow
{
    public class Item
    {
        public string[] tags { get; set; }
        public Owner owner { get; set; }
        public bool is_answered { get; set; }
        public int view_count { get; set; }
        public int bounty_amount { get; set; }
        public int bounty_closes_date { get; set; }
        public int answer_count { get; set; }
        public int score { get; set; }
        public int last_activity_date { get; set; }
        public int creation_date { get; set; }
        public int last_edit_date { get; set; }
        public int question_id { get; set; }
        public string link { get; set; }
        public string title { get; set; }
        public int accepted_answer_id { get; set; }
    }
}