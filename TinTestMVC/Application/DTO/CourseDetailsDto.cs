namespace Application.DTO;

public class CourseDetailsDto
{

    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int MaxNumberOfStudents { get; set; }
    public TutorDto Tutor { get; set; } = default!;
    public List<PersonDto> Persons { get; set; } = new List<PersonDto>();
}

public class TutorDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Specialisation { get; set; } = default!;
}

public class PersonDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}
