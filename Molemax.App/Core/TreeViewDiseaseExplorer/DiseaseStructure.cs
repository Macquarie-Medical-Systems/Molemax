using Molemax.App.Core.TreeViewDiseaseExplorer.Enums;
using Molemax.Models;
using Molemax.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.App.Core.TreeViewDiseaseExplorer
{
    public static class DiseaseStructure
    {
        public static IMolemaxRepository molemaxRepository { get; set; }
        public static List<DiseaseItem> GetFirstLevelCategories()
        {
            var firstLevelCategories = molemaxRepository.DEFAllSkins.Get().Where(i=>i.IsFirstLevelCategory == -1)
                .Select(i=>new DiseaseItem 
                {
                    Type = DataType.CategoryClosed,
                    CategoryOrImageId = i.CategoryOrImageId,
                    DiseaseName = i.DiseaseName
                })
                .OrderBy(i=>i.CategoryOrImageId)
                .ToList();

            int pendingIndex = firstLevelCategories.FindIndex(i => i.DiseaseName == "Diagnosis Pending");
            firstLevelCategories[pendingIndex].Type = DataType.Pending;
            return firstLevelCategories;
        }

        public static List<DiseaseItem> GetDisease(string Id)
        {
            return molemaxRepository.DEFAllSkins.Get().Where(i => i.CategoryOrImageId == Id)
                .Select(i => new DiseaseItem
                {
                    Type = DataType.Disease,
                    CategoryOrImageId = i.CategoryOrImageId,
                    DiseaseName = i.DiseaseName,
                    ParentCategoryId = i.ParentCategoryId,
                    Category = i.Category,
                    Description = i.Description,
                    ImageId = i.ImageId
                }).ToList();
        }

        public static List<DiseaseItem> GetSubCategoriesAndDiseases(string CatogeryId)
        {
            var items = new List<DiseaseItem>();
            try
            {
                var subDiseases = GetSubDiseases(CatogeryId);

                if (subDiseases.Count > 0)
                {
                    items.AddRange(subDiseases.Select(i => new DiseaseItem
                    {
                        CategoryOrImageId = i.CategoryOrImageId,
                        DiseaseName = i.DiseaseName,
                        Type = DataType.Disease,
                        Category = i.Category,
                        Description = i.Description,
                        ImageId = i.ImageId
                    })); ;
                }
            }
            catch
            {
                //TODO: handle exception.
            }
            try
            {
                var subCategories = GetSubCategories(CatogeryId);

                if (subCategories.Count > 0)
                {
                    items.AddRange(subCategories.Select(i => new DiseaseItem
                    {
                        CategoryOrImageId = i.CategoryOrImageId,
                        DiseaseName = i.DiseaseName,
                        Type = DataType.CategoryClosed,

                    }));
                }
            }
            catch
            {
                //TODO: handle exception.
            }

            return items;
        }

        private static List<DiseaseItem> GetSubDiseases(string catogery)
        {
            return molemaxRepository.DEFAllSkins.Get().Where(i => i.ParentCategoryId == catogery && i.CategoryOrImageId.StartsWith("IMAGE"))
                                        .Select(i => new DiseaseItem
                                        {
                                            CategoryOrImageId = i.CategoryOrImageId,
                                            DiseaseName = i.DiseaseName,
                                            Type = DataType.Disease,
                                            Category = i.Category,
                                            Description = i.Description,
                                            ImageId = i.ImageId
                                        })
                                        .OrderBy(i => i.DiseaseName)
                                        .ToList();
        }

        private static List<DiseaseItem> GetSubCategories(string catogery)
        {
            return molemaxRepository.DEFAllSkins.Get().Where(i => i.ParentCategoryId == catogery && i.CategoryOrImageId.StartsWith("DISEASE"))
                                        .Select(i => new DiseaseItem
                                        {
                                            Type = DataType.CategoryClosed,
                                            CategoryOrImageId = i.CategoryOrImageId,
                                            DiseaseName = i.DiseaseName
                                        })
                                        .OrderBy(i => i.DiseaseName)
                                        .ToList();
        }
    }
}
