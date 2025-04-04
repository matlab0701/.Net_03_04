using Domain.Enums;

namespace Domain.Entites;

public class Group
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Status Status { get; set; }
    public DateTimeOffset StartedAt { get; set; }
    public DateTimeOffset FinishedAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public int CourseId { get; set; }

    //navigations
    public Course Course { get; set; }
    public List<StudentGroup> StudentGroups { get; set; }
}
