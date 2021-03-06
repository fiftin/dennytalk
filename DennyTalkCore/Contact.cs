using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace DennyTalk
{
    public class Contact : INotifyPropertyChanged, IPropertyChangeNotifier
    {
        private string nick;
        private string statusText;
        private Address address;
        private UserStatus status;
        private Bitmap avatar;
        private IDictionary<string, object> tag = new Dictionary<string, object>();

        public Contact()
        {
            status = UserStatus.Offline;
        }

        public IDictionary<string, object> Tag
        {
            get { return tag; }
        }

        public Address Address
        {
            get { return address; }
            set
            {
                if (address != value)
                {
                    object oldValue = address;
                    address = value;
                    NotifyPropertyChanged("Address", oldValue, address);
                }
            }
        }

        public Bitmap Avatar
        {
            get
            {
                return avatar;
            }
            set
            {
                if (avatar != value)
                {
                    Bitmap oldValue = avatar;
                    avatar = value;
                    NotifyPropertyChanged("Avatar", oldValue, avatar);
                }
            }
        }

        public string StatusText
        {
            get { return statusText; }
            set
            {
                if (statusText != value)
                {
                    object oldValue = statusText;
                    statusText = value;
                    NotifyPropertyChanged("StatusText", oldValue, value);
                }
            }
        }

        public UserStatus Status
        {
            get { return status; }
            set
            {
                if (status != value)
                {
                    object oldValue = status;
                    status = value;
                    NotifyPropertyChanged("Status", oldValue, value);
                }
            }
        }

        public string Nick
        {
            get { return nick; }
            set
            {
                if (nick != value)
                {
                    object oldValue = nick;
                    nick = value;
                    NotifyPropertyChanged("Nick", oldValue, value);
                }
            }
        }

        public virtual void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void NotifyPropertyChanged(string propertyName, object oldValue, object newValue)
        {
            if (PropertyChange != null)
                PropertyChange(this, new PropertyChangeNotifierEventArgs(propertyName, oldValue, newValue));
            NotifyPropertyChanged(propertyName);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<PropertyChangeNotifierEventArgs> PropertyChange;
    }
}
