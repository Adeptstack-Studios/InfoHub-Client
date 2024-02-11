namespace InfoHub.CustomEventArgs
{
    public class InContentViewClickedEventArgs : EventArgs
    {
        public int Index { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
