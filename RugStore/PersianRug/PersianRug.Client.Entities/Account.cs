using Core.Common.Core;

namespace PersianRug.Client.Entities
{
    public class Account : ObjectBase
    {
        int _AccountId;
        string _LoginEmail;
        string _FirstName;
        string _LastName;
        string _Address;
        string _City;
        string _Province;
        string _PostalCode;
        string _Phone;

        public int AccountId
        {
            get { return _AccountId; }
            set
            {
                if (_AccountId != value)
                {
                    _AccountId = value;
                    OnPropertyChanged(() => AccountId);
                }
            }
        }

        public string LoginEmail
        {
            get { return _LoginEmail; }
            set
            {
                if (_LoginEmail != value)
                {
                    _LoginEmail = value;
                    OnPropertyChanged(() => LoginEmail);
                }
            }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (_FirstName != value)
                {
                    _FirstName = value;
                    OnPropertyChanged(() => FirstName);
                }
            }
        }

        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                    OnPropertyChanged(() => LastName);
                }
            }
        }

        public string Address
        {
            get { return _Address; }
            set
            {
                if (_Address != value)
                {
                    _Address = value;
                    OnPropertyChanged(() => Address);
                }
            }
        }

        public string City
        {
            get { return _City; }
            set
            {
                if (_City != value)
                {
                    _City = value;
                    OnPropertyChanged(() => City);
                }
            }
        }

        public string Province
        {
            get { return _Province; }
            set
            {
                if (_Province != value)
                {
                    _Province = value;
                    OnPropertyChanged(() => Province);
                }
            }
        }

        public string PostalCode
        {
            get { return _PostalCode; }
            set
            {
                if (_PostalCode != value)
                {
                    _PostalCode = value;
                    OnPropertyChanged(() => PostalCode);
                }
            }
        }

        public string Phone
        {
            get { return _Phone; }
            set
            {
                if (_Phone != value)
                {
                    _Phone = value;
                    OnPropertyChanged(() => Phone);
                }
            }
        }
    }
}
