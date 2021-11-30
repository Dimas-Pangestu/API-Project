using System;
using System.Collections.Generic;
using API.Context;
using API.EmployeeRepository;
using API.Models;
using API.ViewModel;
using System.Linq;
using System.Collections;

namespace API.Repository.Data
{
    public class UniversityRepository : GeneralRepository<MyContext, University, int>
    {
        private readonly MyContext context;
        public UniversityRepository(MyContext myContext) : base(myContext)
        {
            context = myContext;
        }

        public IEnumerable GetIdUni()
        {
            var GetUniv = (from p in context.Profiling
                            join ed in context.Education on p.EducationId equals ed.Id
                            join u in context.University on ed.UniversityId equals u.Id
                           group u by new { ed.UniversityId, u.Name } into v
                           select new
                            {
                              
                                resut= "Jumlah lulusan Universitas "+v.Key.Name+" sebanyak "+v.Count()+" Orang",
                              
                            });
            return GetUniv;
        }

        //public IEnumerable<GetProfileVM> GetUniv(int Id)
        //{

        //    var getProfile = (from u in context.University
        //                      where u.Id == Id
        //                      join ed in context.Education on u.Id equals ed.UniversityId
        //                      //join u in context.University on ed.UniversityId equals u.Id
        //                      select new GetProfileVM
        //                      {

        //                          Id = u.Id,
        //                          UniversityId = ed.UniversityId,
        //                          Name = u.Name

        //                      });

        //    return getProfile;

        //}
    }
}