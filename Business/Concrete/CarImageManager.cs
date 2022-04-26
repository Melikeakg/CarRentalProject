using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage, IFormFile formFile)
        {
            IResult result = BusinessRules.Run(CheckLimitCarImage(carImage));
            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            var imageResult = FileHelper.Add(formFile);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = imageResult.Message;
           
            _carImageDal.Add(carImage);
            return new SuccessResult("Car image added");
        }

        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAllCarImages()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetAllCarImagesByCarId(int carId)
        {
            var result = (_carImageDal.GetAll(c => c.CarId == carId));
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<CarImage>>();
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IResult Update(CarImage carImage, IFormFile formFile)
        {
            var image = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
            if (image == null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }

            var updatedFile = FileHelper.Update(formFile, image.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            carImage.ImagePath = updatedFile.Message;
           
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckLimitCarImage(CarImage carImage)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carImage.CarId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
