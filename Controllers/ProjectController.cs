using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using UniResearch.API.Database;
using UniResearch.API.Entity;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly UniResearchContext _dbContext;
    public ProjectController(UniResearchContext dbContext)
    {
        _dbContext = dbContext;
    }

    //[HttpGet]
    //public List<Project> GetProjects(string search)
    //{
    //    var ProjectList = "[{'ProjectId':1,'ProjectName':'non,','Description':'Aliquam ornare, libero at auctor ullamcorper, nisl arcu iaculis','Duration':5,'Budget':'0.69'},{'ProjectId':2,'ProjectName':'orci.','Description':'amet, consectetuer adipiscing elit. Etiam laoreet, libero','Duration':14,'Budget':'9.85'},{'ProjectId':3,'ProjectName':'lacinia','Description':'Donec non justo. Proin non massa non ante bibendum ullamcorper.','Duration':16,'Budget':'3.99'},{'ProjectId':4,'ProjectName':'morbi','Description':'laoreet, libero et tristique pellentesque, tellus sem mollis dui,','Duration':22,'Budget':'3.07'},{'ProjectId':5,'ProjectName':'vitae,','Description':'quam a felis ullamcorper viverra. Maecenas iaculis aliquet','Duration':16,'Budget':'8.41'},{'ProjectId':6,'ProjectName':'consectetuer,','Description':'magna.','Duration':15,'Budget':'4.13'},{'ProjectId':7,'ProjectName':'gravida','Description':'ante ipsum primis in faucibus orci','Duration':21,'Budget':'1.13'},{'ProjectId':8,'ProjectName':'ac','Description':'nec quam. Curabitur','Duration':15,'Budget':'0.63'},{'ProjectId':9,'ProjectName':'dis','Description':'ornare,','Duration':22,'Budget':'7.13'},{'ProjectId':10,'ProjectName':'morbi','Description':'cubilia Curae; Phasellus ornare. Fusce mollis.','Duration':6,'Budget':'1.68'},{'ProjectId':11,'ProjectName':'et,','Description':'augue. Sed molestie. Sed','Duration':2,'Budget':'9.90'},{'ProjectId':12,'ProjectName':'sed,','Description':'scelerisque neque sed sem egestas blandit. Nam nulla','Duration':13,'Budget':'6.47'},{'ProjectId':13,'ProjectName':'neque','Description':'Cras convallis','Duration':5,'Budget':'1.24'},{'ProjectId':14,'ProjectName':'porttitor','Description':'odio tristique pharetra. Quisque','Duration':19,'Budget':'4.81'},{'ProjectId':15,'ProjectName':'vestibulum','Description':'sit amet, consectetuer adipiscing elit. Etiam laoreet,','Duration':2,'Budget':'8.55'},{'ProjectId':16,'ProjectName':'Proin','Description':'pede. Cras vulputate velit eu sem. Pellentesque ut ipsum','Duration':20,'Budget':'4.35'},{'ProjectId':17,'ProjectName':'non','Description':'est tempor bibendum. Donec felis orci, adipiscing non,','Duration':10,'Budget':'2.53'},{'ProjectId':18,'ProjectName':'sodales.','Description':'Nullam feugiat','Duration':12,'Budget':'6.16'},{'ProjectId':19,'ProjectName':'eu,','Description':'nunc sit amet metus. Aliquam erat volutpat.','Duration':24,'Budget':'9.94'},{'ProjectId':20,'ProjectName':'Vestibulum','Description':'elit elit fermentum risus,','Duration':11,'Budget':'3.81'},{'ProjectId':21,'ProjectName':'enim,','Description':'sed, facilisis vitae, orci.','Duration':18,'Budget':'4.21'},{'ProjectId':22,'ProjectName':'lobortis.','Description':'Aliquam','Duration':20,'Budget':'5.98'},{'ProjectId':23,'ProjectName':'orci','Description':'ipsum sodales purus,','Duration':3,'Budget':'8.56'},{'ProjectId':24,'ProjectName':'velit.','Description':'libero. Proin','Duration':22,'Budget':'0.49'},{'ProjectId':25,'ProjectName':'adipiscing','Description':'posuere cubilia Curae; Donec','Duration':20,'Budget':'2.64'},{'ProjectId':26,'ProjectName':'Nulla','Description':'eros. Proin ultrices. Duis volutpat nunc sit','Duration':4,'Budget':'8.90'},{'ProjectId':27,'ProjectName':'Mauris','Description':'enim mi tempor lorem, eget','Duration':22,'Budget':'6.25'},{'ProjectId':28,'ProjectName':'a','Description':'aliquam eu, accumsan sed, facilisis vitae, orci. Phasellus dapibus quam','Duration':8,'Budget':'2.42'},{'ProjectId':29,'ProjectName':'lobortis','Description':'non, lacinia at,','Duration':7,'Budget':'5.38'},{'ProjectId':30,'ProjectName':'consectetuer,','Description':'Aliquam ornare, libero at auctor ullamcorper, nisl','Duration':11,'Budget':'9.07'},{'ProjectId':31,'ProjectName':'gravida.','Description':'risus. Donec nibh','Duration':21,'Budget':'2.38'},{'ProjectId':32,'ProjectName':'natoque','Description':'Nunc lectus pede, ultrices','Duration':10,'Budget':'7.90'},{'ProjectId':33,'ProjectName':'nunc','Description':'diam dictum sapien. Aenean massa. Integer vitae nibh. Donec','Duration':21,'Budget':'0.75'},{'ProjectId':34,'ProjectName':'at,','Description':'rhoncus. Donec est. Nunc ullamcorper, velit in aliquet lobortis,','Duration':11,'Budget':'6.26'},{'ProjectId':35,'ProjectName':'sit','Description':'dui, semper et, lacinia vitae,','Duration':5,'Budget':'9.13'},{'ProjectId':36,'ProjectName':'nec','Description':'Aliquam adipiscing lobortis risus. In mi pede, nonummy','Duration':17,'Budget':'0.85'},{'ProjectId':37,'ProjectName':'Aliquam','Description':'Duis elementum, dui quis accumsan convallis, ante lectus convallis','Duration':19,'Budget':'6.48'},{'ProjectId':38,'ProjectName':'eget','Description':'Nunc quis arcu','Duration':7,'Budget':'6.59'},{'ProjectId':39,'ProjectName':'facilisis,','Description':'magna. Sed eu eros. Nam consequat','Duration':14,'Budget':'8.61'},{'ProjectId':40,'ProjectName':'neque','Description':'vitae sodales nisi magna sed dui. Fusce aliquam, enim nec','Duration':7,'Budget':'2.37'},{'ProjectId':41,'ProjectName':'eleifend','Description':'nunc risus varius orci, in consequat enim diam vel arcu.','Duration':7,'Budget':'1.31'},{'ProjectId':42,'ProjectName':'ornare,','Description':'leo, in lobortis tellus justo sit amet nulla. Donec','Duration':23,'Budget':'3.04'},{'ProjectId':43,'ProjectName':'dui,','Description':'est mauris, rhoncus id, mollis','Duration':13,'Budget':'1.92'},{'ProjectId':44,'ProjectName':'mollis.','Description':'Etiam bibendum fermentum metus. Aenean sed pede nec','Duration':1,'Budget':'1.10'},{'ProjectId':45,'ProjectName':'ac,','Description':'vitae, aliquet nec, imperdiet nec, leo. Morbi neque tellus, imperdiet','Duration':5,'Budget':'7.05'},{'ProjectId':46,'ProjectName':'Duis','Description':'augue. Sed molestie. Sed id','Duration':20,'Budget':'5.50'},{'ProjectId':47,'ProjectName':'mauris','Description':'dui, in sodales','Duration':23,'Budget':'5.70'},{'ProjectId':48,'ProjectName':'Fusce','Description':'lorem tristique aliquet. Phasellus fermentum convallis ligula. Donec luctus aliquet','Duration':20,'Budget':'4.90'},{'ProjectId':49,'ProjectName':'vel','Description':'rhoncus. Nullam velit dui, semper et, lacinia','Duration':4,'Budget':'5.90'},{'ProjectId':50,'ProjectName':'et','Description':'ipsum primis in faucibus orci luctus et','Duration':9,'Budget':'7.25'},{'ProjectId':51,'ProjectName':'Donec','Description':'sodales elit erat','Duration':7,'Budget':'6.41'},{'ProjectId':52,'ProjectName':'sapien.','Description':'pede, ultrices a,','Duration':2,'Budget':'8.91'},{'ProjectId':53,'ProjectName':'semper','Description':'elit elit fermentum risus, at fringilla','Duration':10,'Budget':'5.87'},{'ProjectId':54,'ProjectName':'metus','Description':'dolor sit amet, consectetuer adipiscing elit. Curabitur sed tortor.','Duration':23,'Budget':'3.69'},{'ProjectId':55,'ProjectName':'vitae','Description':'orci lobortis augue scelerisque','Duration':14,'Budget':'4.45'},{'ProjectId':56,'ProjectName':'posuere','Description':'habitant morbi tristique senectus et netus et malesuada fames ac','Duration':21,'Budget':'1.00'},{'ProjectId':57,'ProjectName':'Fusce','Description':'elit sed consequat auctor, nunc nulla vulputate dui, nec tempus','Duration':16,'Budget':'3.43'},{'ProjectId':58,'ProjectName':'semper','Description':'semper cursus. Integer mollis. Integer tincidunt aliquam arcu.','Duration':2,'Budget':'7.97'},{'ProjectId':59,'ProjectName':'quam','Description':'justo sit amet nulla. Donec','Duration':19,'Budget':'6.18'},{'ProjectId':60,'ProjectName':'dignissim','Description':'Sed pharetra, felis eget varius ultrices, mauris','Duration':20,'Budget':'7.80'},{'ProjectId':61,'ProjectName':'scelerisque','Description':'eleifend nec, malesuada ut,','Duration':10,'Budget':'1.28'},{'ProjectId':62,'ProjectName':'dolor.','Description':'volutpat ornare, facilisis eget,','Duration':9,'Budget':'0.54'},{'ProjectId':63,'ProjectName':'ornare','Description':'ornare tortor at','Duration':2,'Budget':'6.36'},{'ProjectId':64,'ProjectName':'quam,','Description':'aliquet molestie tellus. Aenean egestas hendrerit neque. In','Duration':21,'Budget':'2.02'},{'ProjectId':65,'ProjectName':'Nulla','Description':'purus, in molestie tortor','Duration':18,'Budget':'2.02'},{'ProjectId':66,'ProjectName':'tellus','Description':'augue. Sed molestie. Sed id risus quis','Duration':5,'Budget':'3.37'},{'ProjectId':67,'ProjectName':'Sed','Description':'Donec vitae erat','Duration':6,'Budget':'5.90'},{'ProjectId':68,'ProjectName':'orci','Description':'adipiscing fringilla, porttitor vulputate,','Duration':19,'Budget':'0.41'},{'ProjectId':69,'ProjectName':'Maecenas','Description':'tellus.','Duration':20,'Budget':'3.90'},{'ProjectId':70,'ProjectName':'orci,','Description':'egestas. Aliquam fringilla cursus purus. Nullam scelerisque neque sed sem','Duration':3,'Budget':'6.39'},{'ProjectId':71,'ProjectName':'velit','Description':'sed','Duration':4,'Budget':'6.81'},{'ProjectId':72,'ProjectName':'eget,','Description':'Donec tempus, lorem fringilla ornare placerat,','Duration':20,'Budget':'1.64'},{'ProjectId':73,'ProjectName':'neque','Description':'elit, a feugiat','Duration':20,'Budget':'6.65'},{'ProjectId':74,'ProjectName':'Phasellus','Description':'in faucibus orci luctus et ultrices posuere cubilia Curae; Donec','Duration':18,'Budget':'3.51'},{'ProjectId':75,'ProjectName':'tellus','Description':'Cum sociis natoque penatibus et magnis dis parturient','Duration':14,'Budget':'8.26'},{'ProjectId':76,'ProjectName':'feugiat','Description':'odio, auctor vitae,','Duration':12,'Budget':'0.52'},{'ProjectId':77,'ProjectName':'primis','Description':'In faucibus. Morbi vehicula. Pellentesque tincidunt','Duration':11,'Budget':'5.77'},{'ProjectId':78,'ProjectName':'ipsum.','Description':'ante dictum cursus. Nunc mauris elit, dictum eu, eleifend','Duration':17,'Budget':'8.80'},{'ProjectId':79,'ProjectName':'luctus','Description':'eget lacus.','Duration':13,'Budget':'5.00'},{'ProjectId':80,'ProjectName':'sed','Description':'dolor vitae dolor. Donec fringilla. Donec feugiat metus sit amet','Duration':15,'Budget':'6.92'},{'ProjectId':81,'ProjectName':'elit,','Description':'Quisque nonummy ipsum non arcu.','Duration':6,'Budget':'9.20'},{'ProjectId':82,'ProjectName':'risus.','Description':'vitae aliquam eros turpis','Duration':9,'Budget':'5.21'},{'ProjectId':83,'ProjectName':'sapien.','Description':'a, facilisis','Duration':16,'Budget':'7.36'},{'ProjectId':84,'ProjectName':'Mauris','Description':'nonummy ipsum non','Duration':9,'Budget':'4.00'},{'ProjectId':85,'ProjectName':'Morbi','Description':'pretium aliquet, metus urna','Duration':7,'Budget':'5.66'},{'ProjectId':86,'ProjectName':'Duis','Description':'ultrices.','Duration':24,'Budget':'8.19'},{'ProjectId':87,'ProjectName':'Fusce','Description':'cursus vestibulum. Mauris magna. Duis dignissim tempor arcu.','Duration':22,'Budget':'6.90'},{'ProjectId':88,'ProjectName':'magna','Description':'Pellentesque tincidunt tempus risus. Donec egestas. Duis ac arcu. Nunc','Duration':6,'Budget':'7.75'},{'ProjectId':89,'ProjectName':'parturient','Description':'Duis dignissim tempor arcu. Vestibulum ut eros non','Duration':14,'Budget':'0.03'},{'ProjectId':90,'ProjectName':'enim','Description':'senectus et','Duration':10,'Budget':'3.82'},{'ProjectId':91,'ProjectName':'arcu.','Description':'Aliquam nisl. Nulla eu neque pellentesque massa lobortis ultrices. Vivamus','Duration':23,'Budget':'7.02'},{'ProjectId':92,'ProjectName':'adipiscing.','Description':'tellus. Phasellus elit pede, malesuada vel, venenatis vel, faucibus','Duration':7,'Budget':'4.04'},{'ProjectId':93,'ProjectName':'arcu.','Description':'et, euismod et, commodo','Duration':9,'Budget':'1.83'},{'ProjectId':94,'ProjectName':'Pellentesque','Description':'faucibus. Morbi vehicula. Pellentesque tincidunt tempus risus. Donec egestas.','Duration':18,'Budget':'8.26'},{'ProjectId':95,'ProjectName':'ultrices','Description':'tristique pellentesque, tellus sem','Duration':10,'Budget':'7.37'},{'ProjectId':96,'ProjectName':'et,','Description':'parturient','Duration':4,'Budget':'1.94'},{'ProjectId':97,'ProjectName':'Vivamus','Description':'sapien. Cras dolor dolor, tempus non, lacinia','Duration':2,'Budget':'8.29'},{'ProjectId':98,'ProjectName':'felis','Description':'nec','Duration':19,'Budget':'4.40'},{'ProjectId':99,'ProjectName':'faucibus','Description':'leo. Morbi neque tellus,','Duration':6,'Budget':'9.20'},{'ProjectId':100,'ProjectName':'aliquet','Description':'accumsan laoreet ipsum. Curabitur consequat, lectus sit amet luctus vulputate,','Duration':20,'Budget':'4.17'}]";
    //    var Projects = JsonConvert.DeserializeObject<List<Project>>(ProjectList);

    //    if (!string.IsNullOrWhiteSpace(search))
    //    {
    //        var filteredProject = Projects.Where(o => o.ProjectName.ToLower() == search.ToLower()).ToList();
    //        return filteredProject;
    //    }
    //    return Projects;

    //}

    [HttpGet]
    public List<Project> GetProjects(string search) 
    {
        if (!string.IsNullOrWhiteSpace(search)) 
        {
            var query = _dbContext.Projects.Where(o => EF.Functions.Like(o.ProjectName, $"%{search}%"));
            return query.ToList();
        }
        return _dbContext.Projects.ToList();
    }

    [HttpPost]
    public Project Insert(InsertProject model) 
    {
        var project = new Project
        {
            ProjectName = model.ProjectName,
            Description = model.Description,
            Duration = model.Duration,
            Budget = model.Budget
        };

        _dbContext.Projects.Add(project);
        _dbContext.SaveChanges();
        return project;
    }

    [HttpPut("(id)")]

    public Project Update(int id, InsertProject model) 
    {
        var project = _dbContext.Projects.Where(o => o.ProjectId == id).FirstOrDefault();

        project.ProjectName = model.ProjectName;
        project.Description = model.Description;
        project.Duration = model.Duration;
        project.Budget = model.Budget;

        _dbContext.Projects.Update(project);
        _dbContext.SaveChanges();
        return project;
    }

    [HttpGet("(id)")]
    public Project GetById(int id)
    {
        var project = _dbContext.Projects.Where(o => o.ProjectId == id).FirstOrDefault();
        return project;
    }

    [HttpDelete("(id)")]
    public Project DeleteById(int id) 
    {
        var project = _dbContext.Projects.Where(o => o.ProjectId == id).FirstOrDefault();
        _dbContext.Projects.Remove(project);
        _dbContext.SaveChanges();
        return project;
    }
}

public class InsertProject 
{
    public string ProjectName { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public float Budget { get; set; }
}