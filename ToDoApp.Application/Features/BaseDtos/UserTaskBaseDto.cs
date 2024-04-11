

namespace ToDoApp.Application.Features.BaseDtos
{
    public abstract class UserTaskBaseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsCompleted { get; set; }
    }
}
