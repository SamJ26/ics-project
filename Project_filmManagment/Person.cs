﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Project_filmManagment
{

    // TODO: add new class Actor and class Director and use heritage for them

    /// <summary>
    /// This class contains all informations about actors and directors
    /// For every new person, new object from this class need to be created
    /// Both actors and directors have the same class because of simplicity in database mapping
    /// </summary>
    class Person
    {
        // Private fields of the class ( they are private by default )
        TypeOfPerson personsJob;
        string firstName;
        string secondName;
        int age;

        string[] moviesAsActor;
        string[] moviesAsDirector;
        int moviesAsActor_index;                // Keep track of index in array moviesAsActor
        int moviesAsDirector_index;             // Keep track of index in array moviesAsDirector

        // TODO: Photography ????
        // TODO: link to his profil on wiki ???

        // Default constructor which sets the values to properties when new object is created
        public Person()
        {
            personsJob = TypeOfPerson.Undefined;
            firstName = null;
            secondName = null;
            age = 0;
            moviesAsActor = new string[10];             // Default length is 10 because of simplicity of code
            moviesAsDirector = new string[10];          // Default length is 10 because of simplicity of code
            moviesAsActor_index = 0;
            moviesAsDirector_index = 0;
        }

        #region Properties

        // Methods for getting and setting the content of personsJob
        public TypeOfPerson PersonsJob
        {
            get { return personsJob; }
            set { personsJob = value; }
        }

        // Methods for getting and setting the content of variable firstName
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        // Methods for getting and setting the content of variable secondName
        public string SecondName
        {
            get { return secondName; }
            set { secondName = value; }
        }

        // Methods for getting and setting the value of variable age
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        // Method for setting the content of array moviesAsActor
        public string MoviesAsActor
        {
            set
            {
                if (moviesAsActor_index >= 0 && moviesAsActor_index < moviesAsActor.Length)
                    moviesAsActor[moviesAsActor_index] = value;
                ++moviesAsActor_index;
            }
        }

        // Method for setting the content of array moviesAsDirector
        public string MoviesAsDirector
        {
            set
            {
                if (moviesAsDirector_index >= 0 && moviesAsDirector_index < moviesAsDirector.Length)
                    moviesAsDirector[moviesAsDirector_index] = value;
                ++moviesAsDirector_index;
            }
        }

        #endregion

    }
}