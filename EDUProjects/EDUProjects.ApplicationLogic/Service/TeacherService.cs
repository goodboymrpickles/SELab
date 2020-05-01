﻿using CourseManager.ApplicationLogic.Exceptions;
using EDUProjects.ApplicationLogic.Abstractions;
using EDUProjects.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDUProjects.ApplicationLogic.Service
{
   public class TeacherService
    {
        ITeacherRepository teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        public Teacher GetTeacherById(Guid teacherId)
        {

           if(teacherId == null)
            {
                throw new Exception("Null project id");
            }

            return teacherRepository.GetTeacherById(teacherId);
        }

        public IEnumerable<Teacher> GetAll()
        {
            return teacherRepository.GetAll();
        }
    }
}