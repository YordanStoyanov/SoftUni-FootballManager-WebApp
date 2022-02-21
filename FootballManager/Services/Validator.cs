namespace FootballManager.Services
{
    using FootballManager.Data.Models;
    using SMS.Data.Common;
    using System.Security.Cryptography;
    using System.Text;
    using static FootballManager.ViewModels.DataConstants;
    public class Validator : IValidator
    {
        private readonly IRepository repository;
        public Validator(IRepository repository)
        {
            this.repository = repository;
        }
        public bool ValidateUserRegistration(RegisterViewModel model)
        {
            if (model.Username.Length > UsernameMaxLength)
            {
                return false;
            }
            if (model.Email.Length > Email)
            {
                return false;
            }
            if (model.Password.Length > Password)
            {
                return false;
            }
            if (model.ConfirmPossword != model.Password)
            {
                return false;
            }
            return true;
        }
        

        public string Login(LoginViewModel model)
        {
            var user = this.repository.All<User>()
                .Where(u => u.Username == model.Username)
                .Where(u => u.Password == CalculateHash(model.Password))
                .SingleOrDefault();
            return user?.Id;
        }

        public (bool registered, string error) Register(RegisterViewModel model)
        {
            bool registered = false;
            string error = null;

            var (isValid, validationError) = ValidateRegisterModel(model);

            if (!isValid)
            {
                return (isValid, validationError);
            }

            var userPlayer = new UserPlayer();

            var user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Password = CalculateHash(model.Password),
            };
            try
            {
                this.repository.Add(user);
                this.repository.SaveChanges();
                registered = true;
            }
            catch (Exception)
            {
                error = "Can not save in DB!";
            }
            return (registered, error);
        }

        private string CalculateHash(string password)
        {
            byte[] passwordArray = Encoding.UTF8.GetBytes(password);
            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passwordArray));
            }
        }

        private (bool isValid, string error) ValidateRegisterModel(RegisterViewModel model)
        {
            bool isValid = false;
            var error = new StringBuilder();

            if (model == null)
            {
                return (false, "Register model is require!");
            }

            if (model.Username == null || model.Username.Length < 5 || model.Username.Length > 20)
            {
                isValid = false;
                error.AppendLine("Username must be between 5 and 20 symbols");
            }

            if (model.Email == null)
            {
                isValid = false;
                error.AppendLine("Email must be required");
            }


            if (model.Password == null || model.Password.Length < 6 || model.Password.Length > 20)
            {
                isValid = false;
                error.AppendLine("Password must be between 5 and 20 symbols");
            }

            if (model.Password != model.ConfirmPossword)
            {
                isValid = false;
                error.AppendLine("Password and ConfirmPassword bust be equal");
            }

            return (isValid, error.ToString());
        }
    }
}
