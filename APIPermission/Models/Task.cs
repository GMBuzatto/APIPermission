namespace APIPermission.Models
{
    public class Task { 
        public Task(string name, string description)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Description = description;
            IsCompleted = false;
            DateRegister = DateTime.Now;
            DateCompleted = null;
        }
        public string Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public bool IsCompleted { get; private set; }

        public DateTime DateRegister { get; private set; }

        public DateTime? DateCompleted { get; private set; }

        public void UpdateTask(string name, string description, bool? isCompleted)
        {
            Name = name;

            Description = description;

            IsCompleted = isCompleted ?? false;

            DateCompleted = IsCompleted ? DateTime.Now : null;
            if (IsCompleted)
                DateRegister = DateTime.Now;
        }
    }
}
