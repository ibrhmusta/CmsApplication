using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        [ValidationAspect(typeof(CompanyValidator))]
        [SecuredOperation("admin")]
        public IResult Add(Company company)
        {
            company.CreatedDate = System.DateTime.Now;
            company.ModifiedDate = System.DateTime.Now;
            company.IsActive = true;
            company.IsDeleted = false;
            _companyDal.Add(company);
            return new SuccessResult(SuccessMessages.COMPANY_ADDED);
        }

        public IResult Delete(Company company)
        {
            company.IsActive = false;
            company.IsDeleted = true;
            company.ModifiedDate = System.DateTime.Now;
            _companyDal.Update(company);
            return new SuccessResult(SuccessMessages.COMPANY_DELETED);
        }

        public IDataResult<List<Company>> GetAll()
        {
            var result = _companyDal.GetAll();
            return new SuccessDataResult<List<Company>>(result,SuccessMessages.COMPANIES_LISTED);
        }

        public IResult Update(Company company)
        {
            _companyDal.Update(company);
            return new SuccessResult(SuccessMessages.COMPANY_UPDATED);
        }
    }
}
