using GemeinschaftsBalkonWebApp01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GemeinschaftsBalkonWebApp01.Controllers
{
   
    public class AccountController : Controller
    {
        // GET: Account
      
        public ActionResult Login()

        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl) //returnUrl gibt das weiter wo der user hinwollte
        {
            User ulogin;

            if (ModelState.IsValid)
            {
                using (var db = new PflanzEntities())
                {
                    var erg = from u in db.Users
                              where u.U_Name == model.UserName && u.U_PW == model.Password
                              select u;
                    ulogin = erg.FirstOrDefault();
                }

                if (ulogin != null)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);    //1. kontakz zu framework Authentifikation Cookie>web bestes wie frame ein solchees state erhalten kann
                    //username nicht gut zum authentifizieren , deswegen unten in session pK von User
                    Session["uid"] = ulogin.U_ID;
                    return RedirectToLocal("returnUrl");                                    // Url  ?? "~/Home/Index" = gefährlich
                    //url wird unten redirected
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
                //wer bin ich im aktive directory
                //wäre auch sicher für pw
                //oder BCrypt verwenden
                //sonst könnte man moderneres wege einschlagen (pw in eigenen tabelle)
            }
            return View(model);
        }

        
        [HttpPost]                          //Attribute sind ein Form
        [ValidateAntiForgeryToken]          //wird im Rahmen eines hiddenFields übertragen
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))      //überprüft url ob eigene um gefahren zu beschränken
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        /*
         * https://csharpdeveloper.wordpress.com/2012/10/09/use-bcrypt-to-hash-your-passwords-example-for-c-and-sql-server/
         * 
         * 
string myPassword = "password";
string mySalt = BCrypt.GenerateSalt();
//mySalt == "$2a$10$rBV2JDeWW3.vKyeQcM8fFO"
string myHash = BCrypt.HashPassword(myPassword, mySalt);
//myHash == "$2a$10$rBV2JDeWW3.vKyeQcM8fFO4777l4bVeQgDL6VIkxqlzQ7TCalQvla"
bool doesPasswordMatch = BCrypt.CheckPassword(myPassword, myHash);
         * 
         * oder
         * 
private void SetPassword(string user, string userPassword)
{
   string pwdToHash = userPassword + "^Y8~JJ"; // ^Y8~JJ is my hard-coded salt
   string hashToStoreInDatabase = BCrypt.HashPassword(pwdToHash, BCrypt.GenerateSalt());
   using (SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(...)
   {
     sqlConn.Open();
     SqlCommand cmSql = sqlConn.CreateCommand();
     cmSql.CommandText = "UPDATE LOGINS SET PASSWORD=@parm1 WHERE USERNAME=@parm2";
     cmSql.Parameters.Add("@parm1", SqlDbType.Char);
     cmSql.Parameters.Add("@parm2", SqlDbType.VarChar);
     cmSql.Parameters["@parm1"].Value = hashToStoreInDatabase;
     cmSql.Parameters["@parm2"].Value = user;
     cmSql.ExecuteNonQuery();
   }
 }
 
private bool DoesPasswordMatch(string hashedPwdFromDatabase, string userEnteredPassword)
{
    return BCrypt.CheckPassword(userEnteredPassword + "^Y8~JJ", hashedPwdFromDatabase);
}
         */
    }
}