﻿using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }



    //public class UserManager : IUserService
    //{
    //    IUserDal _userDal;
    //    public UserManager(IUserDal userDal)
    //    {
    //        _userDal = userDal;
    //    }

    //    [ValidationAspect(typeof(UserValidator))]
    //    public IResult Add(User user)
    //    {
    //        _userDal.Add(user);
    //        return new SuccessResult(Messages.UserAdded);
    //    }

    //    public IResult Delete(User user)
    //    {
    //        _userDal.Delete(user);
    //        return new SuccessResult(Messages.UserDeleted); 
    //    }

    //    public IDataResult<List<User>> GetAll()
    //    {
    //        return new SuccessDataResult<List<User>>(_userDal.GetAll());
    //    }

    //    public IDataResult<User> GetById(int id)
    //    {
    //        return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == id));
    //    }

    //    [ValidationAspect(typeof(UserValidator))]
    //    public IResult Update(User user)
    //    {
    //        _userDal.Update(user);
    //        return new SuccessResult(Messages.UserUpdated);
    //    }
    //}
}
