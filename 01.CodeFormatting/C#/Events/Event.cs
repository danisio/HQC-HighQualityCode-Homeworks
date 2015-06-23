namespace Events
{
    using System;
    using System.Text;

    public class Event : IComparable
    {
        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public int CompareTo(object obj)
        {
            Event other = obj as Event;
            int eventByDate = this.Date.CompareTo(other.Date);
            int eventByTitle = this.Title.CompareTo(other.Title);
            int eventByLocation = this.Location.CompareTo(other.Location);

            if (eventByDate == 0)
            {
                if (eventByTitle == 0)
                {
                    return eventByLocation;
                }
                else
                {
                    return eventByTitle;
                }
            }
            else
            {
                return eventByDate;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.Date.ToString("yyyy-MM-ddTHH:mm:ss"));
            result.Append(" | " + this.Title);

            if (this.Location != null && this.Location != string.Empty)
            {
                result.Append(" | " + this.Location);
            }

            return result.ToString();
        }
    }
}
