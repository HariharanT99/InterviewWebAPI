using DAL.Data;
using DAL.Repository;
using IDAL.IConfiguration;
using System;

public class Class1
{
	public Class1()
	{
		static void Main()
        {
			var uof = new UnitOfWork("Server=TRAINEE-05;Database=InterviewManagementSystem;User Id=SA;Password=harant@26031999");

			uof.ApplicantRepository.GetApplicantById(2);

			Console.Read();
        }
	}
}
