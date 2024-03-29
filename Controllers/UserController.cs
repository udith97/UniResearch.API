﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UniResearch.API.ControllerServices;
using UniResearch.API.Database;
using UniResearch.API.DTOs;
using UniResearch.API.Entity;

namespace UniResearch.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UniResearchContext _dbContext;

        private readonly UserService _userService;
        public UserController(UniResearchContext dbContext, UserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        //[HttpGet]
        //public List<User> GetUsers(string search) 
        //{
        //    var UserList = "[{'UserId':1,'FirstName':'Malcolm','LastName':'Byers','Email':'risus@tellus.edu','DateofBirth':'05/02/2022'},{'UserId':2,'FirstName':'Lucas','LastName':'Moon','Email':'interdum.Curabitur@ultricies.ca','DateofBirth':'06/28/2021'},{'UserId':3,'FirstName':'Julian','LastName':'Booker','Email':'pede@mauris.com','DateofBirth':'01/06/2022'},{'UserId':4,'FirstName':'Barclay','LastName':'Graham','Email':'Phasellus.ornare.Fusce@orciinconsequat.net','DateofBirth':'02/11/2021'},{'UserId':5,'FirstName':'Justin','LastName':'Barrera','Email':'mollis@liberoduinec.co.uk','DateofBirth':'12/02/2021'},{'UserId':6,'FirstName':'Cain','LastName':'Walter','Email':'Ut.tincidunt.vehicula@atpede.co.uk','DateofBirth':'12/31/2020'},{'UserId':7,'FirstName':'Baker','LastName':'Cortez','Email':'nisl.arcu@pretiumneque.org','DateofBirth':'03/01/2022'},{'UserId':8,'FirstName':'Chester','LastName':'Benjamin','Email':'magna.nec@fringillami.net','DateofBirth':'03/06/2021'},{'UserId':9,'FirstName':'Raymond','LastName':'Finley','Email':'tellus.Nunc.lectus@utipsumac.ca','DateofBirth':'01/14/2021'},{'UserId':10,'FirstName':'Emery','LastName':'Roth','Email':'nulla.Donec@ipsum.org','DateofBirth':'01/02/2022'},{'UserId':11,'FirstName':'Elmo','LastName':'Cantu','Email':'et.magnis.dis@ultricesposuerecubilia.com','DateofBirth':'01/23/2021'},{'UserId':12,'FirstName':'Tarik','LastName':'Peters','Email':'magnis.dis.parturient@tellus.ca','DateofBirth':'11/21/2021'},{'UserId':13,'FirstName':'Reuben','LastName':'Mcintosh','Email':'aliquet@aliquet.co.uk','DateofBirth':'10/05/2020'},{'UserId':14,'FirstName':'Kadeem','LastName':'Garner','Email':'non@molestiearcuSed.co.uk','DateofBirth':'08/30/2020'},{'UserId':15,'FirstName':'Driscoll','LastName':'Clements','Email':'vel@cursusnon.com','DateofBirth':'09/12/2020'},{'UserId':16,'FirstName':'Eaton','LastName':'Hawkins','Email':'Sed.neque.Sed@velarcuCurabitur.edu','DateofBirth':'03/29/2022'},{'UserId':17,'FirstName':'Damon','LastName':'Shepard','Email':'et.magnis.dis@PhasellusornareFusce.net','DateofBirth':'02/01/2021'},{'UserId':18,'FirstName':'Beck','LastName':'Morton','Email':'Donec@morbi.org','DateofBirth':'07/28/2021'},{'UserId':19,'FirstName':'Allistair','LastName':'Tate','Email':'lorem.eget.mollis@Proinultrices.org','DateofBirth':'03/15/2021'},{'UserId':20,'FirstName':'Dexter','LastName':'Duran','Email':'neque@nunc.net','DateofBirth':'10/23/2021'},{'UserId':21,'FirstName':'Adrian','LastName':'Ballard','Email':'Nullam@maurisut.org','DateofBirth':'06/24/2022'},{'UserId':22,'FirstName':'Jason','LastName':'England','Email':'Etiam@euodio.edu','DateofBirth':'01/06/2021'},{'UserId':23,'FirstName':'Gray','LastName':'Scott','Email':'congue.In@velmaurisInteger.edu','DateofBirth':'07/29/2020'},{'UserId':24,'FirstName':'Blaze','LastName':'Holcomb','Email':'quis@pharetrafelis.co.uk','DateofBirth':'05/26/2022'},{'UserId':25,'FirstName':'Rajah','LastName':'Spencer','Email':'Aenean.eget.magna@Curabiturconsequatlectus.co.uk','DateofBirth':'02/17/2021'},{'UserId':26,'FirstName':'Lionel','LastName':'Fuller','Email':'elit.Curabitur@estNunc.co.uk','DateofBirth':'10/29/2020'},{'UserId':27,'FirstName':'Arthur','LastName':'Guthrie','Email':'eget@inceptos.ca','DateofBirth':'09/01/2020'},{'UserId':28,'FirstName':'Buckminster','LastName':'Whitley','Email':'mauris.elit@Aliquam.co.uk','DateofBirth':'06/10/2022'},{'UserId':29,'FirstName':'Steven','LastName':'Bullock','Email':'natoque@nectellus.ca','DateofBirth':'10/04/2020'},{'UserId':30,'FirstName':'Fuller','LastName':'Browning','Email':'mauris@bibendum.com','DateofBirth':'01/02/2021'},{'UserId':31,'FirstName':'Hector','LastName':'Benjamin','Email':'purus.sapien@congueaaliquet.ca','DateofBirth':'03/10/2021'},{'UserId':32,'FirstName':'Nehru','LastName':'Salazar','Email':'ut.molestie@sapienimperdietornare.net','DateofBirth':'11/30/2020'},{'UserId':33,'FirstName':'Walker','LastName':'Gonzalez','Email':'Donec@etnetuset.org','DateofBirth':'06/23/2022'},{'UserId':34,'FirstName':'Anthony','LastName':'Barton','Email':'magna@Maurisblandit.edu','DateofBirth':'02/05/2021'},{'UserId':35,'FirstName':'Harlan','LastName':'Burris','Email':'fermentum.convallis@tellusPhaselluselit.net','DateofBirth':'01/19/2022'},{'UserId':36,'FirstName':'Philip','LastName':'Patrick','Email':'in.lobortis@dapibusligula.co.uk','DateofBirth':'06/06/2022'},{'UserId':37,'FirstName':'Steel','LastName':'Dotson','Email':'dignissim@fringillacursus.ca','DateofBirth':'05/05/2021'},{'UserId':38,'FirstName':'Lucius','LastName':'Hendrix','Email':'nec.cursus.a@Utsemperpretium.org','DateofBirth':'07/17/2021'},{'UserId':39,'FirstName':'Merrill','LastName':'Walters','Email':'a@sedpedeCum.org','DateofBirth':'05/09/2022'},{'UserId':40,'FirstName':'Ulric','LastName':'Harding','Email':'adipiscing@In.net','DateofBirth':'04/14/2022'},{'UserId':41,'FirstName':'Gabriel','LastName':'Stafford','Email':'vulputate.ullamcorper@lobortistellusjusto.edu','DateofBirth':'02/09/2022'},{'UserId':42,'FirstName':'Declan','LastName':'Holt','Email':'odio.Nam.interdum@quismassaMauris.ca','DateofBirth':'08/27/2021'},{'UserId':43,'FirstName':'Derek','LastName':'Crawford','Email':'dictum.sapien.Aenean@Duisgravida.edu','DateofBirth':'06/25/2022'},{'UserId':44,'FirstName':'Lance','LastName':'Townsend','Email':'nascetur.ridiculus.mus@iaculisneceleifend.com','DateofBirth':'11/30/2020'},{'UserId':45,'FirstName':'Kermit','LastName':'Maddox','Email':'sed@massa.ca','DateofBirth':'06/27/2022'},{'UserId':46,'FirstName':'George','LastName':'Chase','Email':'non.bibendum.sed@ante.co.uk','DateofBirth':'08/03/2021'},{'UserId':47,'FirstName':'Jasper','LastName':'Dorsey','Email':'vestibulum.nec.euismod@torquentper.co.uk','DateofBirth':'09/08/2021'},{'UserId':48,'FirstName':'Kato','LastName':'Lott','Email':'velit.Aliquam@neceleifendnon.net','DateofBirth':'09/09/2020'},{'UserId':49,'FirstName':'Ralph','LastName':'Carroll','Email':'auctor.vitae.aliquet@augueid.edu','DateofBirth':'02/08/2021'},{'UserId':50,'FirstName':'Emerson','LastName':'Jensen','Email':'sit.amet@variuseteuismod.com','DateofBirth':'09/05/2021'},{'UserId':51,'FirstName':'Lewis','LastName':'Ellis','Email':'Phasellus@acipsumPhasellus.edu','DateofBirth':'12/26/2021'},{'UserId':52,'FirstName':'Blaze','LastName':'Salazar','Email':'sollicitudin.orci.sem@sit.ca','DateofBirth':'05/01/2021'},{'UserId':53,'FirstName':'Jonas','LastName':'Chen','Email':'nunc.ac.mattis@nuncQuisque.com','DateofBirth':'04/25/2022'},{'UserId':54,'FirstName':'Yasir','LastName':'Kirby','Email':'In@acsem.co.uk','DateofBirth':'07/29/2020'},{'UserId':55,'FirstName':'Sebastian','LastName':'Kelley','Email':'tincidunt.congue@eleifendegestas.ca','DateofBirth':'09/05/2021'},{'UserId':56,'FirstName':'Mark','LastName':'Terry','Email':'enim.Curabitur.massa@volutpat.ca','DateofBirth':'12/15/2021'},{'UserId':57,'FirstName':'Macon','LastName':'Garcia','Email':'elit@semperNam.com','DateofBirth':'07/20/2021'},{'UserId':58,'FirstName':'Timothy','LastName':'Shepherd','Email':'dolor.Nulla@eu.com','DateofBirth':'11/14/2020'},{'UserId':59,'FirstName':'Marsden','LastName':'Fields','Email':'ligula@augueut.ca','DateofBirth':'12/05/2021'},{'UserId':60,'FirstName':'Gregory','LastName':'Vaughan','Email':'congue.In.scelerisque@InloremDonec.co.uk','DateofBirth':'12/26/2021'},{'UserId':61,'FirstName':'Josiah','LastName':'Madden','Email':'pellentesque.massa@Vivamusmolestie.org','DateofBirth':'03/31/2021'},{'UserId':62,'FirstName':'Sawyer','LastName':'Roy','Email':'mauris.sit.amet@dolorsit.co.uk','DateofBirth':'08/12/2021'},{'UserId':63,'FirstName':'Keaton','LastName':'Walls','Email':'ac@Fuscemollis.ca','DateofBirth':'03/14/2022'},{'UserId':64,'FirstName':'Drew','LastName':'Hensley','Email':'auctor.nunc.nulla@Sedegetlacus.net','DateofBirth':'06/12/2021'},{'UserId':65,'FirstName':'Thaddeus','LastName':'Bolton','Email':'vulputate.lacus@Integer.edu','DateofBirth':'08/25/2021'},{'UserId':66,'FirstName':'Trevor','LastName':'Richmond','Email':'dolor.tempus@diameu.net','DateofBirth':'07/19/2021'},{'UserId':67,'FirstName':'Sebastian','LastName':'Serrano','Email':'Sed.dictum@eratvolutpatNulla.co.uk','DateofBirth':'10/28/2021'},{'UserId':68,'FirstName':'Raymond','LastName':'Hanson','Email':'sodales.nisi@velitin.edu','DateofBirth':'04/25/2021'},{'UserId':69,'FirstName':'Wyatt','LastName':'Romero','Email':'semper.Nam@sit.org','DateofBirth':'04/01/2022'},{'UserId':70,'FirstName':'Lucius','LastName':'Blankenship','Email':'tempor.augue.ac@aliquet.org','DateofBirth':'05/13/2022'},{'UserId':71,'FirstName':'Tobias','LastName':'Lott','Email':'dui.Fusce@ipsumdolorsit.net','DateofBirth':'03/21/2021'},{'UserId':72,'FirstName':'Valentine','LastName':'Wagner','Email':'Cras.eget.nisi@Quisque.com','DateofBirth':'10/13/2020'},{'UserId':73,'FirstName':'Zane','LastName':'Montgomery','Email':'dictum.augue@mollisnon.org','DateofBirth':'01/16/2021'},{'UserId':74,'FirstName':'Talon','LastName':'Hall','Email':'amet@augueeutempor.co.uk','DateofBirth':'05/07/2022'},{'UserId':75,'FirstName':'Samuel','LastName':'Christian','Email':'feugiat@nec.edu','DateofBirth':'07/14/2022'},{'UserId':76,'FirstName':'Harper','LastName':'Gilliam','Email':'viverra.Maecenas@molestiearcuSed.org','DateofBirth':'04/07/2021'},{'UserId':77,'FirstName':'Wesley','LastName':'Park','Email':'Etiam.laoreet.libero@amet.net','DateofBirth':'08/10/2020'},{'UserId':78,'FirstName':'Kareem','LastName':'Vega','Email':'nisl@Quisquetincidunt.edu','DateofBirth':'11/22/2020'},{'UserId':79,'FirstName':'Avram','LastName':'Hinton','Email':'posuere.enim@Vestibulumanteipsum.ca','DateofBirth':'12/11/2021'},{'UserId':80,'FirstName':'Upton','LastName':'Chambers','Email':'amet.nulla@magnaSed.ca','DateofBirth':'03/12/2021'},{'UserId':81,'FirstName':'Plato','LastName':'Wilkins','Email':'dapibus.id.blandit@Fusce.co.uk','DateofBirth':'10/02/2021'},{'UserId':82,'FirstName':'Gavin','LastName':'Blevins','Email':'erat.vel@iaculisenimsit.com','DateofBirth':'09/13/2020'},{'UserId':83,'FirstName':'Vincent','LastName':'Vang','Email':'pede.Cum@fermentummetus.com','DateofBirth':'10/15/2021'},{'UserId':84,'FirstName':'Gannon','LastName':'Wolf','Email':'in@miloremvehicula.edu','DateofBirth':'08/15/2021'},{'UserId':85,'FirstName':'Blake','LastName':'Shannon','Email':'massa@lectuspede.ca','DateofBirth':'10/06/2021'},{'UserId':86,'FirstName':'Palmer','LastName':'Miles','Email':'orci@varius.ca','DateofBirth':'09/20/2021'},{'UserId':87,'FirstName':'Isaiah','LastName':'Adkins','Email':'fringilla.purus@Pellentesque.edu','DateofBirth':'06/04/2022'},{'UserId':88,'FirstName':'Sean','LastName':'Guzman','Email':'Duis.a@Etiam.com','DateofBirth':'06/11/2022'},{'UserId':89,'FirstName':'Cooper','LastName':'Puckett','Email':'enim.Sed@commodoipsum.edu','DateofBirth':'11/24/2020'},{'UserId':90,'FirstName':'Carson','LastName':'Lindsay','Email':'eget.odio@dictumaugue.net','DateofBirth':'01/14/2021'},{'UserId':91,'FirstName':'Gil','LastName':'Sparks','Email':'In.ornare.sagittis@PhasellusornareFusce.ca','DateofBirth':'02/23/2022'},{'UserId':92,'FirstName':'Cadman','LastName':'Buchanan','Email':'eu@Namligula.org','DateofBirth':'06/17/2022'},{'UserId':93,'FirstName':'James','LastName':'Emerson','Email':'lacus.Nulla@quamelementum.co.uk','DateofBirth':'07/26/2020'},{'UserId':94,'FirstName':'Alden','LastName':'Peterson','Email':'egestas.lacinia.Sed@eratSednunc.edu','DateofBirth':'10/10/2020'},{'UserId':95,'FirstName':'Leo','LastName':'Herman','Email':'Integer.vulputate@ipsumporta.net','DateofBirth':'06/03/2022'},{'UserId':96,'FirstName':'Raphael','LastName':'Barry','Email':'turpis.Nulla@leoCrasvehicula.co.uk','DateofBirth':'07/22/2022'},{'UserId':97,'FirstName':'Amal','LastName':'Guthrie','Email':'enim@cursusdiam.com','DateofBirth':'07/07/2021'},{'UserId':98,'FirstName':'Brett','LastName':'Travis','Email':'lobortis.Class.aptent@cursusin.ca','DateofBirth':'02/24/2022'},{'UserId':99,'FirstName':'Tyler','LastName':'Bolton','Email':'tristique.ac.eleifend@pedenonummyut.edu','DateofBirth':'10/09/2020'},{'UserId':100,'FirstName':'Kasper','LastName':'Hood','Email':'pharetra@ametornare.edu','DateofBirth':'08/13/2020'}]";
        //    var Users = JsonConvert.DeserializeObject<List<User>>(UserList);

        //    if (!string.IsNullOrWhiteSpace(search)) {
        //        var filteredUsers = Users.Where(o => o.FirstName.ToLower() == search.ToLower() || o.LastName.ToLower() == search.ToLower()).ToList();
        //        return filteredUsers;
        //    }
        //    return Users;

        //}

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetUsers(string search) 
        {
            return await _userService.GetUsers(search);
        }

        [HttpPost]
        public ActionResult<User> Insert(InsertUser model) 
        {
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                DateofBirth = model.DateofBirth,
                UserType = model.UserType
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        [HttpPut("{id}")]
        public ActionResult<User> Update(int id, InsertUser model) 
        {

            try
            {
                var erros = SetErrors(model);
                if (erros.Errors.Count() > 0)
                {
                    return BadRequest(erros.Errors);
                }

                var user = _dbContext.Users.FirstOrDefault(o => o.UserId == id);

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.DateofBirth = model.DateofBirth;
                user.UserType = model.UserType;

                _dbContext.Users.Update(user);
                _dbContext.SaveChanges();
                return user;
            }
            catch (Exception EX) 
            {
                return Problem("There was an error updating User record.");
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

        public ValidationError SetErrors(InsertUser model)
        {
            var validationerror = new ValidationError();
            if (string.IsNullOrWhiteSpace(model.FirstName))
            {
                validationerror.Errors.Add("FirstName", "FirstName is required.");
            }
            if (model.FirstName.Length > 50)
            {
                validationerror.Errors.Add("FirstName", "FirstName  too long.");
            }
            if (string.IsNullOrWhiteSpace(model.LastName))
            {
                validationerror.Errors.Add("LastName", "LastName is required.");
            }
            if (model.LastName.Length > 50)
            {
                validationerror.Errors.Add("LastName", "LastName is required.");
            }
            if (string.IsNullOrWhiteSpace(model.Email))
            {
                validationerror.Errors.Add("Email", "Email is required.");
            }
            if (model.Email.Length > 100)
            {
                validationerror.Errors.Add("Email", "Email is required.");
            }
            if (!(model.UserType != null))
            {
                validationerror.Errors.Add("UserType", "UserType is required.");
            }


            //TODO: Add more validations here

            return validationerror;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            return await _userService.GetByIdAsync(id);

        }

        [HttpDelete("{id}")]
        public ActionResult<User> DeleteById(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(o => o.UserId == id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
                return Ok("Object Deleted.");
            }

            return NoContent();
        }

    }

    public class InsertUser 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateofBirth { get; set; }
        public UserType UserType { get; set; }
        //public string Hash { get; set; }
        //public string Salt { get; set; }
    }
}
