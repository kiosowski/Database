namespace SoftJail.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentsCells = JsonConvert.DeserializeObject<DepartmentDto[]>(jsonString);
            var sb = new StringBuilder();
            var departments = new List<Department>();
            
            foreach (var dto in departmentsCells)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                var cells = new List<Cell>();
                foreach (var cellDto in dto.Cells)
                {
                    if (!IsValid(cellDto))
                    {
                        sb.AppendLine("Invalid Data");
                        break;
                    }
                    Cell cell = new Cell
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow
                    };
                    cells.Add(cell);
                }
                if (cells.Count == 0)
                {
                    continue;
                }
                Department department = new Department
                {
                    Name = dto.Name,
                    Cells = cells
                };
                departments.Add(department);

                sb.AppendLine($"Imported {dto.Name} with {dto.Cells.Count()} cells");
            }
            context.Departments.AddRange(departments);
            context.SaveChanges();
            var result = sb.ToString();
            return result;
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisoners = JsonConvert.DeserializeObject<PrisonerDto[]>(jsonString);
            var sb = new StringBuilder();
            var prisonersList = new List<Prisoner>();
           
            foreach (var dto in prisoners)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                var mails = new List<Mail>();
                foreach (var dtoMail in dto.Mails)
                {
                    if (!IsValid(dtoMail.Address))
                    {
                        sb.AppendLine("Invalid Data");
                        break;
                    }
                    var newMail = new Mail
                    {
                        Description = dtoMail.Description,
                        Sender = dtoMail.Sender,
                        Address = dtoMail.Address
                    };
                    mails.Add(newMail);
                }
                if (mails.Count == 0)
                {
                    continue;
                }
                    var incDate = DateTime.TryParseExact(dto.IncarcerationDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime IncarcerationDate);
                    DateTime.TryParseExact(dto.ReleaseDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime ReleaseDate);
                    Prisoner prisoner = new Prisoner
                    {
                        FullName = dto.FullName,
                        Nickname = dto.Nickname,
                        Age = dto.Age,
                        IncarcerationDate = IncarcerationDate,
                        ReleaseDate = ReleaseDate,
                        Bail = dto.Bail,
                        CellId = dto.CellId,
                        Mails = mails
                    };
                    prisonersList.Add(prisoner);
                    sb.AppendLine($"Imported {dto.FullName} {dto.Age} years old");

            }
            context.Prisoners.AddRange(prisonersList);
            context.SaveChanges();
            var result = sb.ToString();
            return result;
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }
        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}