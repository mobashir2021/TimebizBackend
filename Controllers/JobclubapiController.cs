using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JobclubBackend.common;
using JobclubBackend.Models;
using Newtonsoft.Json;


namespace JobclubBackend.Controllers
{
    
    

    [RoutePrefix("api/Jobclubapi")]
    public class JobclubapiController : ApiController
    {
        string ApiUrl = "http://www.fjfgroups.com/Upload/";
        TimebizjobsEntities db = new TimebizjobsEntities();

        [HttpGet]
        public HttpResponseMessage TestData()
        {
            
            try
            {
                var testdata = "Success";
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(testdata));
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }



        }

        [AllowCrossSiteJson]
        [HttpGet]
        public HttpResponseMessage TimebizEmployeezoneRegister(string companyname, string email, string website, string Phoneno, string address, string district)
        {
            try
            {
                Timebizuser timebizuser = new Timebizuser();
                timebizuser.Username = email;
                timebizuser.Password = "";
                timebizuser.Email = email;
                timebizuser.Roles = "Employer";
                db.Timebizusers.Add(timebizuser);

                db.SaveChanges();

                TimebizCompany timebiz = new TimebizCompany();
                timebiz.Address = address;
                timebiz.Companyname = companyname;
                timebiz.District = district;
                timebiz.Email = email;
                timebiz.Phoneno = Phoneno;
                timebiz.Website = website;
                timebiz.Userid = timebizuser.Userid;

                timebiz.islogincreated = "false";
                db.TimebizCompanies.Add(timebiz);

                timebizuser.Companyid = timebiz.Companyid;
                timebizuser.Email = timebiz.Email;
                db.Entry(timebizuser).State = EntityState.Modified;
                db.SaveChanges();

                string resvalue = "Registered Successfully";
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(resvalue));
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        [AllowCrossSiteJson]
        [HttpGet]
        public HttpResponseMessage TimebizJobPost(int Companyid, string Jobtitle, string Category, string Designation, string Description, string Salary, string Vacancies)
        {
            try
            {
                TimebizJob timebiz = new TimebizJob();

                timebiz.Companyid = Companyid;
                timebiz.JobTitle = Jobtitle;
                timebiz.Category = Category;
                timebiz.Designation = Designation;
                timebiz.Description = Description;
                timebiz.Salary = Convert.ToInt32(Salary);
                timebiz.Vacancy = Convert.ToInt32(Vacancies);
                db.TimebizJobs.Add(timebiz);
                db.SaveChanges();
                string resvalue = "JobPosted Successfully";
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(resvalue));
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        [AllowCrossSiteJson]
        [HttpGet]
        public HttpResponseMessage TimebizJobSeekerzoneRegister(string Name, string username, string email, string Password, string Mobileno, string Qualification, string Experience, string Skills,
            string Address, string District, string Gender)
        {
            try
            {
                Timebizuser timebiz = new Timebizuser();
                timebiz.Name = Name;
                timebiz.Email = email;
                timebiz.District = District;
                timebiz.Password = Password;
                timebiz.Mobileno = Mobileno;
                timebiz.qualitfications = Qualification;
                timebiz.Username = username;
                timebiz.Experience = Experience;
                timebiz.Skills = Skills;
                timebiz.Address = Address;
                timebiz.Gender = Gender;
                timebiz.Username = email;
                timebiz.Roles = "JobSeeker";
                db.Timebizusers.Add(timebiz);
                db.SaveChanges();
                string resvalue = "Registered Successfully";
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(resvalue));
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        [AllowCrossSiteJson]
        [HttpGet]
        public HttpResponseMessage TimeBizEmployerLogintry(string Username, string Password)
        {
            try
            {

                var result = db.Timebizusers.Where(x => x.Username.ToLower() == Username.ToLower() && x.Password == Password && x.Roles == "Employer");
                string resvalue = string.Empty;
                if (result.Count() > 0)
                {
                    resvalue = "Login Successful";
                }
                else
                {
                    resvalue = "Login Failed";
                }

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(resvalue));
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        [AllowCrossSiteJson]
        [HttpGet]
        public HttpResponseMessage TimeBizJobSeekerLogintry(string Username, string Password)
        {
            try
            {

                var result = db.Timebizusers.Where(x => x.Username.ToLower() == Username.ToLower() && x.Password == Password && x.Roles == "JobSeeker");
                string resvalue = string.Empty;
                if (result.Count() > 0)
                {
                    resvalue = "Login Successful";
                }
                else
                {
                    resvalue = "Login Failed";
                }

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(resvalue));
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        [AllowCrossSiteJson]
        [HttpGet]
        public HttpResponseMessage TimeBizEmployerLogin(string Username, string Password)
        {
            try
            {
                Usertimebiz usertimebiz = new Usertimebiz();
                var comps = db.TimebizCompanies.ToList();

                var result = db.Timebizusers.Where(x => x.Username.ToLower() == Username.ToLower() && x.Password == Password && x.Roles == "Employer").ToList();


                if (result.Count > 0)
                {
                    Timebizuser user = result[0];
                    TimebizCompany com = comps.Where(x => x.Userid == user.Userid).First();
                    usertimebiz.Address = com.Address;
                    usertimebiz.Companyid = com.Companyid.ToString();
                    usertimebiz.Companyname = com.Companyname;
                    usertimebiz.District = com.District;
                    usertimebiz.Email = user.Email;
                    usertimebiz.Mobileno = com.Mobileno;
                    usertimebiz.Password = user.Password;
                    usertimebiz.Roles = "Employer";
                    usertimebiz.Userid = user.Userid;
                }

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                if (result.Count > 0)
                {
                    response.Content = new StringContent(JsonConvert.SerializeObject(usertimebiz));
                }
                else
                {
                    usertimebiz.Address = "No data exists";
                    response.Content = new StringContent(JsonConvert.SerializeObject(usertimebiz));
                }

                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;
            }
            catch (Exception ex)
            {
                //return new HttpResponseMessage(HttpStatusCode.BadRequest);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("Myerror : " + ex.Message.ToString() + "---" + ex.InnerException.Message.ToString())
                };
            }
        }

        [AllowCrossSiteJson]
        [HttpGet]
        public HttpResponseMessage TimeBizListJobs(int companyid)
        {
            try
            {
                List<timebizPostedJobs> lst = new List<timebizPostedJobs>();
                var result = db.TimebizJobs.Where(x => x.Companyid == companyid).ToList();
                foreach (var temp in result)
                {
                    timebizPostedJobs jobs = new timebizPostedJobs();
                    jobs.Companyid = companyid;
                    jobs.Description = temp.Description;
                    jobs.Designation = temp.Designation;
                    jobs.JobId = temp.Jobid;
                    jobs.JobTitle = temp.JobTitle;
                    jobs.Vacancy = temp.Vacancy.HasValue ? temp.Vacancy.Value : 0;
                    lst.Add(jobs);
                }

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(lst));
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [AllowCrossSiteJson]
        [HttpGet]
        public HttpResponseMessage TimeBizListJobsCandidates(int jobid)
        {
            try
            {
                List<Jobscandidate> lst = new List<Jobscandidate>();
                List<Timebizuser> users = db.Timebizusers.ToList();
                List<TimebizJob> jobsdata = db.TimebizJobs.ToList();
                var result = db.JobApplications.Where(x => x.Jobid == jobid).ToList();
                foreach (var temp in result)
                {
                    Jobscandidate jobs = new Jobscandidate();
                    Timebizuser user = users.Where(x => x.Userid == temp.Userid).First();
                    TimebizJob job = jobsdata.Where(x => x.Jobid == jobid).First();
                    jobs.Name = user.Name;
                    jobs.Userid = temp.Userid.Value;
                    jobs.Designation = job.Designation;
                    jobs.Experience = user.Experience;
                    jobs.Qualification = user.qualitfications;
                    jobs.Resumepath = temp.resumepath;
                    jobs.Skills = user.Skills;

                    lst.Add(jobs);
                }

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(lst));
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [AllowCrossSiteJson]
        [HttpGet]
        public HttpResponseMessage TimeBizApplyjob(string Jobid, string Userid, string filename)
        {
            try
            {

                var users = db.Timebizusers.Where(x => x.Userid == Convert.ToInt32(Userid)).First();
                var jobsdata = db.TimebizJobs.Where(x => x.Jobid == Convert.ToInt32(Jobid)).First();
                var companies = db.TimebizCompanies.Where(x => x.Companyid == jobsdata.Companyid).First();

                JobApplication jobs = new JobApplication();

                jobs.AppliedDate = DateTime.Now;
                jobs.Companyid = companies.Companyid;
                jobs.Jobid = jobsdata.Jobid;
                jobs.resumepath = @"http://www.fjfgroups.com/resumepath/" + filename;
                jobs.Userid = users.Userid;
                db.JobApplications.Add(jobs);
                db.SaveChanges();

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject("Job applied Successfully"));
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [AllowCrossSiteJson]
        [HttpGet]
        public HttpResponseMessage TimeBizJobSearchbyDistrictAndCategory(string district, string category)
        {
            try
            {
                List<TimebizJobsList> lst = new List<TimebizJobsList>();

                List<Timebizuser> users = db.Timebizusers.ToList();
                List<TimebizJob> jobsdata = db.TimebizJobs.ToList();
                List<TimebizCompany> companies = db.TimebizCompanies.ToList();
                List<TimebizCompany> filteredCompany = companies;
                List<TimebizJob> filteredJobs = jobsdata;
                if (district != "")
                {
                    filteredCompany = companies.Where(x => x.District.ToLower() == district.ToLower()).ToList();
                }
                if (category != "")
                {
                    filteredJobs = jobsdata.Where(x => x.Category == category).ToList();
                }

                var result = (from fc in filteredCompany
                              join fj in filteredJobs on fc.Companyid equals fj.Companyid
                              select new { fc, fj }).ToList();


                foreach (var temp in result)
                {
                    TimebizJobsList obj = new TimebizJobsList();
                    obj.Category = temp.fj.Category;
                    obj.Companyid = temp.fc.Companyid.ToString();
                    obj.Companyname = temp.fc.Companyname;
                    obj.Description = temp.fj.Description;
                    obj.Designation = temp.fj.Designation;
                    obj.District = temp.fc.District;
                    obj.Experience = temp.fj.Experience;
                    obj.Jobid = temp.fj.Jobid;
                    obj.JobTitle = temp.fj.JobTitle;
                    obj.Salary = temp.fj.Salary.HasValue ? temp.fj.Salary.Value.ToString() : "";
                    obj.Vacancies = temp.fj.Vacancy.HasValue ? temp.fj.Vacancy.Value.ToString() : "";
                    obj.Skills = temp.fj.Skills;
                    lst.Add(obj);
                }

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(lst));
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [AllowCrossSiteJson]
        [HttpGet]
        public HttpResponseMessage TimeBizJobSearchbyKeyword(string keyword)
        {
            try
            {
                List<TimebizJobsList> lst = new List<TimebizJobsList>();

                List<Timebizuser> users = db.Timebizusers.ToList();
                List<TimebizJob> jobsdata = db.TimebizJobs.ToList();
                List<TimebizCompany> companies = db.TimebizCompanies.ToList();
                List<TimebizCompany> filteredCompany = companies;
                List<TimebizJob> filteredJobs = jobsdata;

                if (keyword != "")
                {
                    filteredJobs = jobsdata.Where(x => x.Skills.ToLower().Trim().Contains(keyword.ToLower().Trim())).ToList();
                }

                var result = (from fc in filteredCompany
                              join fj in filteredJobs on fc.Companyid equals fj.Companyid
                              select new { fc, fj }).ToList();


                foreach (var temp in result)
                {
                    TimebizJobsList obj = new TimebizJobsList();
                    obj.Category = temp.fj.Category;
                    obj.Companyid = temp.fc.Companyid.ToString();
                    obj.Companyname = temp.fc.Companyname;
                    obj.Description = temp.fj.Description;
                    obj.Designation = temp.fj.Designation;
                    obj.District = temp.fc.District;
                    obj.Experience = temp.fj.Experience;
                    obj.Jobid = temp.fj.Jobid;
                    obj.JobTitle = temp.fj.JobTitle;
                    obj.Salary = temp.fj.Salary.HasValue ? temp.fj.Salary.Value.ToString() : "";
                    obj.Vacancies = temp.fj.Vacancy.HasValue ? temp.fj.Vacancy.Value.ToString() : "";
                    obj.Skills = temp.fj.Skills;
                    lst.Add(obj);
                }

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(lst));
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [AllowCrossSiteJson]
        [HttpGet]
        public HttpResponseMessage TimeBizLoadCompany()
        {
            try
            {
                List<TimebizJobsList> lst = new List<TimebizJobsList>();

                List<TimebizCompany> result = db.TimebizCompanies.ToList();


                foreach (var temp in result)
                {
                    TimebizJobsList obj = new TimebizJobsList();

                    obj.Companyid = temp.Companyid.ToString();
                    obj.Companyname = temp.Companyname;

                    lst.Add(obj);
                }

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(lst));
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [AllowCrossSiteJson]
        [HttpGet]
        public HttpResponseMessage TimeBizJobSearchbyCompany(string companyname)
        {
            try
            {
                List<TimebizJobsList> lst = new List<TimebizJobsList>();

                List<Timebizuser> users = db.Timebizusers.ToList();
                List<TimebizJob> jobsdata = db.TimebizJobs.ToList();
                List<TimebizCompany> companies = db.TimebizCompanies.ToList();
                List<TimebizCompany> filteredCompany = companies;
                List<TimebizJob> filteredJobs = jobsdata;
                if (companyname != "")
                {
                    filteredCompany = companies.Where(x => x.Companyname.ToLower() == companyname.ToLower()).ToList();
                }


                var result = (from fc in filteredCompany
                              join fj in filteredJobs on fc.Companyid equals fj.Companyid
                              select new { fc, fj }).ToList();


                foreach (var temp in result)
                {
                    TimebizJobsList obj = new TimebizJobsList();
                    obj.Category = temp.fj.Category;
                    obj.Companyid = temp.fc.Companyid.ToString();
                    obj.Companyname = temp.fc.Companyname;
                    obj.Description = temp.fj.Description;
                    obj.Designation = temp.fj.Designation;
                    obj.District = temp.fc.District;
                    obj.Experience = temp.fj.Experience;
                    obj.Jobid = temp.fj.Jobid;
                    obj.JobTitle = temp.fj.JobTitle;
                    obj.Salary = temp.fj.Salary.HasValue ? temp.fj.Salary.Value.ToString() : "";
                    obj.Vacancies = temp.fj.Vacancy.HasValue ? temp.fj.Vacancy.Value.ToString() : "";
                    obj.Skills = temp.fj.Skills;
                    lst.Add(obj);
                }

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(lst));
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [AllowCrossSiteJson]
        [HttpGet]
        public HttpResponseMessage TimebizLoginJobseeker(string Username, string Password)
        {
            try
            {

                Usertimebiz usertimebiz = new Usertimebiz();


                var result = db.Timebizusers.Where(x => x.Username.ToLower() == Username.ToLower() && x.Password == Password && x.Roles == "JobSeeker").ToList();


                if (result.Count > 0)
                {
                    Timebizuser user = result[0];

                    usertimebiz.Address = user.Address;

                    usertimebiz.District = user.District;
                    usertimebiz.Email = user.Email;
                    usertimebiz.Mobileno = user.Mobileno;
                    usertimebiz.Password = user.Password;
                    usertimebiz.Roles = "JobSeeker";
                    usertimebiz.Userid = user.Userid;
                }

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                if (result.Count > 0)
                {
                    response.Content = new StringContent(JsonConvert.SerializeObject(usertimebiz));
                }
                else
                {
                    usertimebiz.Address = "No data exists";
                    response.Content = new StringContent(JsonConvert.SerializeObject(usertimebiz));
                }
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
