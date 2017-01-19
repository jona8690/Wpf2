﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf2
{
    class Controler
    {
        private static Controler instance;
        private Repository repository;
        public Person CurentPerson { get; private set; }
        public int PersonCount { get; private set; }
        public int PersonIndex { get; private set; }

        private Controler()
        {
			CurentPerson = new Person();
            repository = new Repository();
            PersonCount = 0;
            PersonIndex = -1;
        }
        public static Controler GetInstance()
        {
            if (instance== null)
            {
                instance = new Controler();
            }
            return instance;
        }

        public void AddPerson()
        {
			Person person = new Person();
			person.FirstName = CurentPerson.FirstName;
			person.LastName = CurentPerson.LastName;
			person.Age = CurentPerson.Age;
			person.TelephoneNr = CurentPerson.TelephoneNr;

			repository.AddPerson(person);
			PersonCount = repository.PersonList.Count();
			PersonIndex = PersonCount - 1;
		}

        public void DeletePerson()
        {
            if (CurentPerson != null)
            {
                repository.RemovePerson(CurentPerson);
                PersonIndex--;
                PersonCount = repository.PersonList.Count();
                CurentPerson = repository.GetPersonAtIndex(PersonIndex);
            }
        }

        public void NextPerson()
        {
            if (PersonIndex < PersonCount - 1)
            {
                PersonIndex++;
                CurentPerson = repository.GetPersonAtIndex(PersonIndex);
            }
        }
        public void PrevPerson()
        {
            if (PersonIndex > 0)
            {
                PersonIndex--;
                CurentPerson = repository.GetPersonAtIndex(PersonIndex);
            }
        }


    }
}
