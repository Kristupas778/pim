using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Google.Contacts;
using Google.GData.Contacts;
using Google.GData.Client;
using Google.GData.Extensions;




namespace PimWebApp
{
    public class ServicesContacts
    {
        public void PrintDateMinQueryResults(ContactsRequest cr)
        {
            ContactsQuery query = new ContactsQuery(ContactsQuery.CreateContactsUri("default"));
            query.StartDate = new DateTime(2008, 1, 1);
            Feed<Contact> feed = cr.Get<Contact>(query);
            foreach (Contact contact in feed.Entries)
            {
                Console.WriteLine(contact.Name.FullName);
                Console.WriteLine("Updated on: " + contact.Updated.ToString());
            }
        }

        /*Creando conctactos a traves del servicio de google Contacts*/
        public static Contact CreateContact(ContactsRequest cr)
        {
            Contact newEntry = new Contact();
            // Set the contact's name.
            newEntry.Name = new Name()
            {
                FullName = "Elizabeth Bennet",
                GivenName = "Elizabeth",
                FamilyName = "Bennet",
            };
            newEntry.Content = "Notes";
            // Set the contact's e-mail addresses.
            newEntry.Emails.Add(new EMail()
            {
                Primary = true,
                Rel = ContactsRelationships.IsHome,
                Address = "liz@gmail.com"
            });
            newEntry.Emails.Add(new EMail()
            {
                Rel = ContactsRelationships.IsWork,
                Address = "liz@example.com"
            });
            // Set the contact's phone numbers.
            newEntry.Phonenumbers.Add(new PhoneNumber()
            {
                Primary = true,
                Rel = ContactsRelationships.IsWork,
                Value = "(206)555-1212",
            });
            newEntry.Phonenumbers.Add(new PhoneNumber()
            {
                Rel = ContactsRelationships.IsHome,
                Value = "(206)555-1213",
            });
            // Set the contact's IM information.
            newEntry.IMs.Add(new IMAddress()
            {
                Primary = true,
                Rel = ContactsRelationships.IsHome,
                Protocol = ContactsProtocols.IsGoogleTalk,
            });
            // Set the contact's postal address.
            newEntry.PostalAddresses.Add(new StructuredPostalAddress()
            {
                Rel = ContactsRelationships.IsWork,
                Primary = true,
                Street = "1600 Amphitheatre Pkwy",
                City = "Mountain View",
                Region = "CA",
                Postcode = "94043",
                Country = "United States",
                FormattedAddress = "1600 Amphitheatre Pkwy Mountain View",
            });
            // Insert the contact.
            Uri feedUri = new Uri(ContactsQuery.CreateContactsUri("default"));
            Contact createdEntry = cr.Insert(feedUri, newEntry);
            Console.WriteLine("Contact's ID: " + createdEntry.Id);
  return createdEntry;
        }

        /*Actualizando la lista de contactos*/
       
        public static Contact UpdateContactName(ContactsRequest cr, Uri contactURL)
        {
            // First, retrieve the contact to update.
            Contact contact = cr.Retrieve<Contact>(contactURL);
            contact.Name.FullName = "New Name";
            contact.Name.GivenName = "New";
            contact.Name.FamilyName = "Name";
            try
            {
                Contact updatedContact = cr.Update(contact);
                //Console.WriteLine("Updated: " + updatedEntry.Updated.ToString());
              return updatedContact;
            }
            catch (GDataVersionConflictException e)
            {
                // Etags mismatch: handle the exception.
                //If - Match: Etag
            }
            return null;
        }

    }
}
