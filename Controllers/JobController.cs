using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniResearch.API.Database;

namespace UniResearch.API.Entity
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobController : ControllerBase
    {
        private readonly UniResearchContext _dbContext;
        public JobController(UniResearchContext dbContext)
        {
            _dbContext = dbContext;
        }

        //[HttpGet]
        //public List<Job> GetJobs(string search)
        //{
        //    var JobList = "[{'JobId':1,'Salary':'6.55','CompanyName':'Tincidunt Inc.','Description':'gravida. Aliquam tincidunt, nunc ac mattis ornare, lectus ante dictum','Location':'Lithuania'},{'JobId':2,'Salary':'7.34','CompanyName':'Quis Accumsan Convallis Company','Description':'lacus. Nulla tincidunt, neque','Location':'Qatar'},{'JobId':3,'Salary':'2.89','CompanyName':'Elit Industries','Description':'luctus et ultrices posuere cubilia','Location':'Somalia'},{'JobId':4,'Salary':'9.16','CompanyName':'Magna Nam PC','Description':'nulla at sem molestie sodales.','Location':'Guinea'},{'JobId':5,'Salary':'4.78','CompanyName':'Id Magna Company','Description':'dolor. Nulla semper tellus id nunc interdum feugiat. Sed nec','Location':'Algeria'},{'JobId':6,'Salary':'3.22','CompanyName':'Pellentesque Limited','Description':'tempus mauris erat eget ipsum. Suspendisse sagittis. Nullam vitae','Location':'Portugal'},{'JobId':7,'Salary':'5.83','CompanyName':'Porttitor Eros Nec Institute','Description':'ultrices a,','Location':'Congo (Brazzaville)'},{'JobId':8,'Salary':'5.05','CompanyName':'Luctus Ut Pellentesque Associates','Description':'arcu ac orci. Ut semper pretium neque. Morbi quis urna.','Location':'Ecuador'},{'JobId':9,'Salary':'3.15','CompanyName':'Dictum Associates','Description':'tempus','Location':'France'},{'JobId':10,'Salary':'0.50','CompanyName':'In Incorporated','Description':'arcu. Sed et libero. Proin mi. Aliquam gravida mauris ut','Location':'Indonesia'},{'JobId':11,'Salary':'6.63','CompanyName':'Quisque Libero Company','Description':'Quisque porttitor eros nec tellus.','Location':'Trinidad and Tobago'},{'JobId':12,'Salary':'1.37','CompanyName':'Ornare Foundation','Description':'dictum','Location':'Singapore'},{'JobId':13,'Salary':'6.04','CompanyName':'Dis Parturient Montes PC','Description':'sem, vitae aliquam eros turpis non enim. Mauris','Location':'Somalia'},{'JobId':14,'Salary':'8.69','CompanyName':'Est Tempor LLP','Description':'iaculis, lacus pede sagittis','Location':'Libya'},{'JobId':15,'Salary':'9.16','CompanyName':'Quam A Felis Corp.','Description':'elit sed consequat auctor, nunc nulla','Location':'Cuba'},{'JobId':16,'Salary':'0.35','CompanyName':'Congue Consulting','Description':'rutrum. Fusce dolor quam, elementum at, egestas a, scelerisque','Location':'Trinidad and Tobago'},{'JobId':17,'Salary':'3.34','CompanyName':'Augue Sed Molestie Consulting','Description':'ac','Location':'Togo'},{'JobId':18,'Salary':'1.93','CompanyName':'Tortor Nunc Commodo Incorporated','Description':'dolor sit amet, consectetuer','Location':'Suriname'},{'JobId':19,'Salary':'2.91','CompanyName':'Sollicitudin Corporation','Description':'arcu. Sed et libero. Proin mi. Aliquam','Location':'Pakistan'},{'JobId':20,'Salary':'6.84','CompanyName':'Elit Aliquam Auctor Ltd','Description':'est, vitae sodales nisi magna','Location':'Haiti'},{'JobId':21,'Salary':'8.17','CompanyName':'Luctus Consulting','Description':'orci lacus vestibulum lorem,','Location':'New Caledonia'},{'JobId':22,'Salary':'2.29','CompanyName':'Tellus Sem Associates','Description':'diam dictum sapien. Aenean massa. Integer vitae','Location':'Barbados'},{'JobId':23,'Salary':'1.99','CompanyName':'Aptent Taciti Consulting','Description':'risus. Morbi metus. Vivamus euismod urna. Nullam lobortis','Location':'Uzbekistan'},{'JobId':24,'Salary':'5.12','CompanyName':'Malesuada PC','Description':'amet, faucibus ut, nulla. Cras eu tellus','Location':'Togo'},{'JobId':25,'Salary':'9.21','CompanyName':'Lorem Ipsum LLC','Description':'placerat eget, venenatis a, magna. Lorem ipsum','Location':'Virgin Islands, British'},{'JobId':26,'Salary':'6.34','CompanyName':'Pede Cras Vulputate Consulting','Description':'bibendum ullamcorper.','Location':'Palau'},{'JobId':27,'Salary':'5.60','CompanyName':'Ipsum Non Inc.','Description':'rhoncus.','Location':'Uruguay'},{'JobId':28,'Salary':'7.39','CompanyName':'Placerat Cras Dictum Limited','Description':'tristique senectus et netus','Location':'Austria'},{'JobId':29,'Salary':'2.15','CompanyName':'Adipiscing Fringilla Limited','Description':'Nulla eu neque pellentesque massa lobortis ultrices. Vivamus rhoncus. Donec','Location':'India'},{'JobId':30,'Salary':'5.29','CompanyName':'Id Magna Et LLP','Description':'non justo. Proin non massa non','Location':'Cambodia'},{'JobId':31,'Salary':'5.24','CompanyName':'Libero Limited','Description':'sed,','Location':'French Polynesia'},{'JobId':32,'Salary':'4.72','CompanyName':'Risus Institute','Description':'tincidunt nibh. Phasellus nulla. Integer vulputate, risus','Location':'Chad'},{'JobId':33,'Salary':'9.36','CompanyName':'Elit Pretium Company','Description':'turpis nec mauris blandit mattis. Cras eget','Location':'Bonaire, Sint Eustatius and Saba'},{'JobId':34,'Salary':'9.12','CompanyName':'Eleifend Vitae Erat Consulting','Description':'gravida. Praesent','Location':'Sweden'},{'JobId':35,'Salary':'5.13','CompanyName':'Nunc Sed Pede Corporation','Description':'Duis volutpat nunc sit amet metus. Aliquam erat volutpat. Nulla','Location':'Azerbaijan'},{'JobId':36,'Salary':'0.20','CompanyName':'Nec Leo Morbi Industries','Description':'pede nec ante blandit','Location':'Western Sahara'},{'JobId':37,'Salary':'7.34','CompanyName':'Vivamus Consulting','Description':'luctus ut,','Location':'Mozambique'},{'JobId':38,'Salary':'4.65','CompanyName':'Eu Accumsan Sed PC','Description':'nonummy ultricies ornare, elit','Location':'Nicaragua'},{'JobId':39,'Salary':'9.79','CompanyName':'Nibh Foundation','Description':'a sollicitudin orci sem eget massa. Suspendisse eleifend.','Location':'Bahrain'},{'JobId':40,'Salary':'9.89','CompanyName':'Id Nunc Interdum Institute','Description':'Sed diam lorem,','Location':'Argentina'},{'JobId':41,'Salary':'1.47','CompanyName':'Felis Associates','Description':'Praesent','Location':'Malawi'},{'JobId':42,'Salary':'9.26','CompanyName':'Sagittis Semper PC','Description':'vitae semper','Location':'Belgium'},{'JobId':43,'Salary':'3.25','CompanyName':'Rhoncus Foundation','Description':'orci luctus et ultrices posuere cubilia Curae; Phasellus ornare. Fusce','Location':'Afghanistan'},{'JobId':44,'Salary':'4.47','CompanyName':'Luctus Vulputate Consulting','Description':'sociosqu ad litora torquent per conubia nostra, per','Location':'Estonia'},{'JobId':45,'Salary':'2.88','CompanyName':'Sem Egestas Blandit Foundation','Description':'quis diam luctus lobortis. Class aptent taciti','Location':'Liechtenstein'},{'JobId':46,'Salary':'8.64','CompanyName':'Tellus Sem Mollis Inc.','Description':'Donec feugiat metus sit amet ante. Vivamus non lorem vitae','Location':'Georgia'},{'JobId':47,'Salary':'8.43','CompanyName':'Purus Mauris A Ltd','Description':'orci. Phasellus dapibus quam quis diam. Pellentesque','Location':'South Georgia and The South Sandwich Islands'},{'JobId':48,'Salary':'3.87','CompanyName':'Tortor LLC','Description':'sem. Pellentesque ut ipsum ac mi eleifend egestas. Sed','Location':'Portugal'},{'JobId':49,'Salary':'3.68','CompanyName':'Orci LLP','Description':'libero est, congue a, aliquet vel, vulputate eu,','Location':'Antarctica'},{'JobId':50,'Salary':'9.68','CompanyName':'Sollicitudin LLC','Description':'ut mi. Duis risus odio, auctor vitae, aliquet nec,','Location':'Macao'},{'JobId':51,'Salary':'0.63','CompanyName':'Ultricies Ornare Elit Consulting','Description':'rutrum non, hendrerit id, ante. Nunc mauris sapien, cursus','Location':'Isle of Man'},{'JobId':52,'Salary':'7.79','CompanyName':'Integer Vitae Consulting','Description':'egestas rhoncus. Proin nisl sem, consequat nec, mollis vitae, posuere','Location':'Singapore'},{'JobId':53,'Salary':'1.01','CompanyName':'Mi Incorporated','Description':'arcu. Aliquam ultrices iaculis odio.','Location':'Montserrat'},{'JobId':54,'Salary':'9.90','CompanyName':'Rutrum Urna Nec Ltd','Description':'Curabitur','Location':'Iran'},{'JobId':55,'Salary':'4.69','CompanyName':'Amet Faucibus Ut Associates','Description':'eu sem. Pellentesque ut ipsum ac mi','Location':'Cape Verde'},{'JobId':56,'Salary':'7.10','CompanyName':'Elementum At PC','Description':'Nunc pulvinar arcu et pede. Nunc sed orci lobortis augue','Location':'Dominican Republic'},{'JobId':57,'Salary':'7.17','CompanyName':'Tortor Integer Aliquam Inc.','Description':'orci, adipiscing non, luctus sit amet, faucibus','Location':'Mozambique'},{'JobId':58,'Salary':'5.25','CompanyName':'Purus Gravida Corp.','Description':'arcu. Morbi sit amet massa. Quisque porttitor eros nec tellus.','Location':'British Indian Ocean Territory'},{'JobId':59,'Salary':'3.12','CompanyName':'Malesuada Integer PC','Description':'commodo auctor velit. Aliquam nisl. Nulla eu neque pellentesque','Location':'Virgin Islands, United States'},{'JobId':60,'Salary':'2.65','CompanyName':'Magna Praesent Interdum Inc.','Description':'vel,','Location':'Oman'},{'JobId':61,'Salary':'1.02','CompanyName':'Massa Suspendisse Institute','Description':'Cum sociis natoque penatibus et magnis dis parturient montes,','Location':'Kiribati'},{'JobId':62,'Salary':'6.99','CompanyName':'Urna Incorporated','Description':'aliquet nec, imperdiet nec, leo. Morbi neque','Location':'Sri Lanka'},{'JobId':63,'Salary':'4.47','CompanyName':'A Corporation','Description':'lectus. Cum sociis natoque penatibus et magnis','Location':'Cyprus'},{'JobId':64,'Salary':'2.69','CompanyName':'Cras Sed Company','Description':'a neque. Nullam ut nisi a odio semper cursus. Integer','Location':'Sint Maarten'},{'JobId':65,'Salary':'6.77','CompanyName':'Sodales Nisi Company','Description':'lobortis. Class aptent taciti sociosqu ad','Location':'Mongolia'},{'JobId':66,'Salary':'1.59','CompanyName':'Libero Morbi Industries','Description':'ornare, lectus ante dictum mi, ac mattis','Location':'Monaco'},{'JobId':67,'Salary':'5.41','CompanyName':'Et Arcu Imperdiet Associates','Description':'magna. Praesent interdum ligula eu enim. Etiam imperdiet dictum','Location':'Martinique'},{'JobId':68,'Salary':'9.64','CompanyName':'In Scelerisque Scelerisque Industries','Description':'faucibus','Location':'Tokelau'},{'JobId':69,'Salary':'7.01','CompanyName':'Arcu Inc.','Description':'Proin velit. Sed','Location':'Oman'},{'JobId':70,'Salary':'1.64','CompanyName':'Proin Non Massa Ltd','Description':'Curabitur dictum. Phasellus in felis. Nulla tempor augue ac','Location':'Saint Lucia'},{'JobId':71,'Salary':'8.99','CompanyName':'Phasellus LLP','Description':'at','Location':'Isle of Man'},{'JobId':72,'Salary':'1.46','CompanyName':'Ullamcorper Duis LLP','Description':'ante dictum mi, ac mattis velit justo','Location':'Hong Kong'},{'JobId':73,'Salary':'2.41','CompanyName':'Elementum Lorem Foundation','Description':'ornare, libero at auctor ullamcorper, nisl arcu iaculis','Location':'Barbados'},{'JobId':74,'Salary':'7.65','CompanyName':'Non Inc.','Description':'Nam nulla magna,','Location':'Sao Tome and Principe'},{'JobId':75,'Salary':'0.92','CompanyName':'Imperdiet Ornare In Institute','Description':'erat volutpat.','Location':'Jamaica'},{'JobId':76,'Salary':'5.01','CompanyName':'Mollis LLC','Description':'augue ac ipsum. Phasellus','Location':'Saint Barthélemy'},{'JobId':77,'Salary':'8.93','CompanyName':'Felis Purus Ac Limited','Description':'at, nisi. Cum sociis natoque penatibus et magnis','Location':'Kuwait'},{'JobId':78,'Salary':'2.59','CompanyName':'Nec Luctus LLP','Description':'dui. Fusce diam nunc, ullamcorper eu, euismod ac, fermentum vel,','Location':'Guatemala'},{'JobId':79,'Salary':'6.21','CompanyName':'Nec Orci Donec Corp.','Description':'erat vel pede blandit','Location':'Kyrgyzstan'},{'JobId':80,'Salary':'4.62','CompanyName':'Et Malesuada Fames LLP','Description':'arcu et pede. Nunc','Location':'Dominican Republic'},{'JobId':81,'Salary':'4.85','CompanyName':'Sem Egestas Blandit Associates','Description':'ligula tortor, dictum eu, placerat eget, venenatis a, magna. Lorem','Location':'Comoros'},{'JobId':82,'Salary':'4.20','CompanyName':'Sagittis Company','Description':'Suspendisse eleifend. Cras sed leo. Cras vehicula aliquet libero.','Location':'Sweden'},{'JobId':83,'Salary':'7.82','CompanyName':'Tempor PC','Description':'dolor. Fusce feugiat. Lorem ipsum dolor sit','Location':'Cambodia'},{'JobId':84,'Salary':'4.19','CompanyName':'Massa Vestibulum Accumsan LLP','Description':'eu lacus. Quisque imperdiet, erat nonummy ultricies ornare, elit elit','Location':'Swaziland'},{'JobId':85,'Salary':'3.59','CompanyName':'Arcu Inc.','Description':'feugiat metus sit amet ante. Vivamus non','Location':'United Arab Emirates'},{'JobId':86,'Salary':'5.01','CompanyName':'Diam Dictum Sapien LLC','Description':'mauris blandit mattis. Cras eget nisi dictum augue malesuada malesuada.','Location':'Angola'},{'JobId':87,'Salary':'9.62','CompanyName':'Sodales Nisi Magna Incorporated','Description':'tempus mauris erat eget','Location':'South Africa'},{'JobId':88,'Salary':'7.63','CompanyName':'Aliquet Odio Etiam Incorporated','Description':'bibendum fermentum metus. Aenean sed pede nec ante blandit viverra.','Location':'American Samoa'},{'JobId':89,'Salary':'4.04','CompanyName':'Nec Cursus A Ltd','Description':'at augue id ante dictum cursus. Nunc mauris','Location':'Bonaire, Sint Eustatius and Saba'},{'JobId':90,'Salary':'3.46','CompanyName':'Laoreet LLP','Description':'et, rutrum non,','Location':'Guam'},{'JobId':91,'Salary':'3.98','CompanyName':'Suspendisse Aliquet Corp.','Description':'placerat eget,','Location':'Zambia'},{'JobId':92,'Salary':'8.43','CompanyName':'Vulputate Dui Nec Inc.','Description':'faucibus orci luctus et ultrices posuere cubilia Curae;','Location':'Saint Kitts and Nevis'},{'JobId':93,'Salary':'6.86','CompanyName':'Pede Nunc PC','Description':'vel, mauris. Integer sem elit, pharetra ut, pharetra','Location':'Palestine, State of'},{'JobId':94,'Salary':'6.65','CompanyName':'Hendrerit Id Ante Inc.','Description':'lobortis ultrices. Vivamus rhoncus.','Location':'Bangladesh'},{'JobId':95,'Salary':'9.05','CompanyName':'Rutrum Eu LLP','Description':'erat semper rutrum. Fusce dolor quam,','Location':'Sao Tome and Principe'},{'JobId':96,'Salary':'6.69','CompanyName':'Nec Diam Incorporated','Description':'non massa non ante bibendum ullamcorper.','Location':'Saint Kitts and Nevis'},{'JobId':97,'Salary':'5.29','CompanyName':'Integer Urna Vivamus Company','Description':'arcu. Sed et libero. Proin mi. Aliquam','Location':'Saint Helena, Ascension and Tristan da Cunha'},{'JobId':98,'Salary':'9.75','CompanyName':'Interdum Curabitur Institute','Description':'Fusce dolor quam,','Location':'Portugal'},{'JobId':99,'Salary':'4.15','CompanyName':'In Dolor Fusce Institute','Description':'in, dolor. Fusce feugiat.','Location':'Saint Lucia'},{'JobId':100,'Salary':'2.90','CompanyName':'Nulla Vulputate Incorporated','Description':'mollis. Phasellus libero mauris, aliquam eu, accumsan','Location':'Sri Lanka'}]";
        //    var Jobs = JsonConvert.DeserializeObject<List<Job>>(JobList);

        //    if (!string.IsNullOrWhiteSpace(search))
        //    {
        //        var filteredJobs = Jobs.Where(o => o.CompanyName.ToLower() == search.ToLower() || o.Location.ToLower() == search.ToLower()).ToList();
        //        return filteredJobs;
        //    }
        //    return Jobs;

        //}

        [HttpGet]
        public List<Job> GetJobs(string search)
        {
            if (!string.IsNullOrWhiteSpace(search))
            {
                var query = _dbContext.Jobs.Where(o => EF.Functions.Like(o.CompanyName, $"%{search}%") || EF.Functions.Like(o.Location, $"%{search}%"));
                //var sql = query.ToQueryString();
                return query.ToList();


            }
            return _dbContext.Jobs.ToList();

        }

        [HttpPost]
        public ActionResult<Job> Insert(InsertJob model)
        {
            var job = new Job
            {
                CompanyName = model.CompanyName,
                Description = model.Description,
                JobType = model.JobType,
                Location = model.Location,
                Salary = model.Salary
            };

            _dbContext.Jobs.Add(job);
            _dbContext.SaveChanges();
            return job;
        }

        [HttpPut("{id}")]
        public ActionResult<Job> Update(int id, InsertJob model) 
        {
            try
            {
                var erros = SetErrors(model);
                if (erros.Errors.Count() > 0)
                {
                    return BadRequest(erros.Errors);
                }

                var job = _dbContext.Jobs.FirstOrDefault(o => o.JobId == id);

                job.CompanyName = model.CompanyName;
                job.Description = model.Description;
                job.JobType = model.JobType;
                job.Location = model.Location;
                job.Salary = model.Salary;


                _dbContext.Jobs.Update(job);
                _dbContext.SaveChanges();
                return job;
            }
            catch (Exception ex) 
            {
                return Problem("There was an error updating Job record.");
            }
        }

        public class ValidationError
        {
            public ValidationError()
            {
                Errors = new Dictionary<string, string>();
            }
            public Dictionary<string, string> Errors { get; set; }
        }

        public ValidationError SetErrors(InsertJob model)
        {
            var validationerror = new ValidationError();
            if (string.IsNullOrWhiteSpace(model.CompanyName))
            {
                validationerror.Errors.Add("CompanyName", "CompanyName  is required.");
            }
            if (model.CompanyName.Length > 100)
            {
                validationerror.Errors.Add("CompanyName", "CompanyName too long.");
            }
            if (string.IsNullOrWhiteSpace(model.Description))
            {
                validationerror.Errors.Add("Description", "Description is required.");
            }
            if (!(model.JobType != null))
            {
                validationerror.Errors.Add("JobType", "JobType is required.");
            }
            if (string.IsNullOrWhiteSpace(model.Location))
            {
                validationerror.Errors.Add("Location", "Location  is required.");
            }
            if (!(model.Salary != null))
            {
                validationerror.Errors.Add("Salary", "Budget is required.");
            }

            //TODO: Add more validations here

            return validationerror;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetById(int id)
        {
            var job = await _dbContext.Jobs
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.JobId == id);

            if (job != null)
            {
                return Ok(job);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Job> DeleteById(int id)
        {
            var job = _dbContext.Jobs.FirstOrDefault(o => o.JobId == id);
            if (job != null)
            {
                _dbContext.Jobs.Remove(job);
                _dbContext.SaveChanges();
                return Ok("Object Deleted.");
            }

            return NoContent();
        }

    }

    public class InsertJob
    {
        public JobType JobType { get; set; }
        public float Salary { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

    }
}

