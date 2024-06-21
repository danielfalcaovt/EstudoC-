using ContextosDeConteudo.NotificationContext;

namespace ContextosDeConteudo.Contextos
{
    public class CareerItem : Base
    {
        public int Order { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Course Course { get; set; }
        public CareerItem(int order, string title, string description, Course course)
        {                    
            if (course == null)
            {
                AddNotification(new Notification("Course", "Course can not be null"));
            }
            else
            {
                Order = order;
                Title = title;
                Description = description;
                Course = course;
            }
        }
    }
}