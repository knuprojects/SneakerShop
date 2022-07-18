using Catalogue.Application.Commands.Category.CreateCategory;
using Catalogue.Application.Commands.Category.DeleteCategory;
using Catalogue.Application.Commands.Category.UpdateCategory;
using Catalogue.Application.Commands.Companies.CreateCompany;
using Catalogue.Application.Commands.Companies.DeleteCompany;
using Catalogue.Application.Commands.Companies.UpdateCompany;
using Catalogue.Application.Commands.Sneakers.CreateSneaker;
using Catalogue.Application.Commands.Sneakers.DeleteSneaker;
using Catalogue.Application.Commands.Sneakers.UpdateSneaker;
using Catalogue.Application.Dto;
using Catalogue.Domain.Entities;

namespace Catalogue.Application.Mapper
{
    public static class Mapping
    {
        #region CompanyCommand
        public static CreateCompanyDto CreateCommandCompany(this CreateCompanyCommand createCompanyCommand)
        {
            return new CreateCompanyDto
            {
                Name = createCompanyCommand.Name,
                Deleted = createCompanyCommand.Deleted
            };
        }

        public static UpDateCompanyDto UpdateCommandCompany(this UpdateCompanyCommand updateCompanyCommand)
        {
            return new UpDateCompanyDto
            {
                CompanyId = updateCompanyCommand.CompanyId,
                Name = updateCompanyCommand.Name,
                Deleted = updateCompanyCommand.Deleted
            };
        }

        public static DeleteCompanyDto DeleteCommandCompany(this DeleteCompanyCommand deleteCompanyCommand)
        {
            return new DeleteCompanyDto
            {
                CompanyId = deleteCompanyCommand.CompanyId,
                Deleted = deleteCompanyCommand.Deleted
            };
        }
        #endregion

        #region CompanyDto To Company

        public static Company CreateCompanyDtoToCompany(this CreateCompanyDto createCompanyDto)
        {
            return new Company
            {
                Name = createCompanyDto.Name,
                Deleted = createCompanyDto.Deleted
            };
        }

        public static Company UpdateCompanyDtoToCompany(this UpDateCompanyDto upDateCompanyDto)
        {
            return new Company
            {
                CompanyId = upDateCompanyDto.CompanyId,
                Name = upDateCompanyDto.Name,
                Deleted = upDateCompanyDto.Deleted
            };
        }

        #endregion

        #region SneakerCommand
        public static CreateSneakerDto CreateCommandSneaker(this CreateSneakerCommand createSneakerCommand)
        {
            return new CreateSneakerDto
            {
                Name = createSneakerCommand.Name,
                Price = createSneakerCommand.Price,
                Size = createSneakerCommand.Size,
                Colour = createSneakerCommand.Colour,
                PhotoUrl = createSneakerCommand.PhotoUrl,
                IsFavourite = createSneakerCommand.IsFavourite,
                Deleted = createSneakerCommand.Deleted,
                CategoryId = createSneakerCommand.CategoryId,
                CompanyId = createSneakerCommand.CompanyId
            };
        }

        public static UpDateSneakerDto UpdateCommandSneaker(this UpdateSneakerCommand updateSneakerCommand)
        {
            return new UpDateSneakerDto
            {
                SneakerId = updateSneakerCommand.SneakerId,
                Name = updateSneakerCommand.Name,
                Price = updateSneakerCommand.Price,
                Size = updateSneakerCommand.Size,
                Colour = updateSneakerCommand.Colour,
                PhotoUrl = updateSneakerCommand.PhotoUrl,
                IsFavourite = updateSneakerCommand.IsFavourite,
                Deleted = updateSneakerCommand.Deleted,
                CategoryId = updateSneakerCommand.CategoryId,
                CompanyId = updateSneakerCommand.CompanyId
            };
        }

        public static DeleteSneakerDto DeleteCommandSneaker(this DeleteSneakerCommand deleteSneakerCommand)
        {
            return new DeleteSneakerDto
            {
                SneakerId = deleteSneakerCommand.SneakerId,
                Deleted = deleteSneakerCommand.Deleted
            };
        }

        #endregion

        #region SneakerDto To Sneaker
        public static Sneaker CreateSneakerDtoToSneaker(this CreateSneakerDto createSneakerDto)
        {
            return new Sneaker
            {
                Name = createSneakerDto.Name,
                Price = createSneakerDto.Price,
                Size = createSneakerDto.Size,
                Colour = createSneakerDto.Colour,
                PhotoUrl = createSneakerDto.PhotoUrl,
                IsFavourite = createSneakerDto.IsFavourite,
                Deleted = createSneakerDto.Deleted,
                CategoryId = createSneakerDto.CategoryId,
                CompanyId = createSneakerDto.CompanyId
            };
        }

        public static Sneaker UpdateSneakerDtoToSneaker(this UpDateSneakerDto updateSneakerDto)
        {
            return new Sneaker
            {
                SneakerId = updateSneakerDto.SneakerId,
                Name = updateSneakerDto.Name,
                Price = updateSneakerDto.Price,
                Size = updateSneakerDto.Size,
                Colour = updateSneakerDto.Colour,
                PhotoUrl = updateSneakerDto.PhotoUrl,
                IsFavourite = updateSneakerDto.IsFavourite,
                Deleted = updateSneakerDto.Deleted,
                CategoryId = updateSneakerDto.CategoryId,
                CompanyId = updateSneakerDto.CompanyId
            };
        }

        #endregion

        #region CategoryCommand

        public static CreateCategoryDto CreateCommandCategory(this CreateCategoryCommand createCategoryCommand)
        {
            return new CreateCategoryDto
            {
                Name = createCategoryCommand.Name,
                Deleted = createCategoryCommand.Deleted,
                CompanyId = createCategoryCommand.CompanyId
            };
        }

        public static DeleteCategoryDto DeleteCommandCategory(this DeleteCategoryCommand deleteCategoryCommand)
        {
            return new DeleteCategoryDto
            {
                CategoryId = deleteCategoryCommand.CategoryId,
                Deleted = deleteCategoryCommand.Deleted
            };
        }

        public static UpDateCategoryDto UpdateCommandCategory(this UpdateCategoryCommand updateCategoryCommand)
        {
            return new UpDateCategoryDto
            {
                CategoryId = updateCategoryCommand.CategoryId,
                Name = updateCategoryCommand.Name,
                Deleted = updateCategoryCommand.Deleted,
                CompanyId = updateCategoryCommand.CompanyId
            };
        }

        #endregion

        #region CategoryDto To Category

        public static Category CreateCategoryDtoToCategory(this CreateCategoryDto createCategoryDto)
        {
            return new Category
            {
                Name = createCategoryDto.Name,
                Deleted = createCategoryDto.Deleted,
                CompanyId = createCategoryDto.CompanyId
            };
        }

        public static Category UpdateCategoryDtoToCategory(this UpDateCategoryDto upDateCategoryDto)
        {
            return new Category
            {
                CategoryId = upDateCategoryDto.CategoryId,
                Name = upDateCategoryDto.Name,
                Deleted = upDateCategoryDto.Deleted,
                CompanyId = upDateCategoryDto.CompanyId
            };
        }

        #endregion
    }
}
