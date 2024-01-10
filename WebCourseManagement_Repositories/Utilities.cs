using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebCourseManagement_Commons.DefaultConstants;
using WebCourseManagement_Commons.HandleExceptions;
using WebCourseManagement_Models.Entities;

namespace WebCourseManagement_Repositories
{
    public static class Utilities
    {
        private static readonly ConcurrentDictionary<string, string> DisplayNameCache = new ConcurrentDictionary<string, string>();

        public static IQueryable<TSource> ApplyPaging<TSource>(this IQueryable<TSource> source, int pageNo, int pageSize)
        {
            return pageSize > 0 ? source.Skip((pageNo - 1) * pageSize).Take(pageSize) : source;
        }

        public static IQueryable<TSource> ApplyPaging<TSource>(this IQueryable<TSource> source, int pageNo, int pageSize, out int totalItem)
        {
            totalItem = source.Count();
            return pageSize > 0 ? source.Skip((pageNo - 1) * pageSize).Take(pageSize) : source;
        }

        public static T GetById<T>(this DbSet<T> entity, long id) where T : BaseEntity
        {
            var record = entity.Find(id);
            if (record == null)
            {
                throw new Exception(Constants.ExceptionMessage.ITEM_NOT_FOUND);
            }
            return record;
        }
        
        public static bool PasswordValid(this string password)
        {
            //var pattern = @"^\S{6,}$";
            var pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\W).+$";
            return Regex.IsMatch(password, pattern);
        }
        public static bool IsValidEmail(string email)
        {
            var emailAttribute = new EmailAddressAttribute();
            return emailAttribute.IsValid(email);
        }
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^(84|0[35789])[0-9]{8}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }
        public static string ConvertToUrlFriendly(string str)
        {
            str = str.ToLower();
            str = Regex.Replace(str, "/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ|a/g", "a");
            str = Regex.Replace(str, "/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ|e/g", "e");
            str = Regex.Replace(str, "/ì|í|ị|ỉ|ĩ|i/g", "i");
            str = Regex.Replace(str, "/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ|o/g", "o");
            str = Regex.Replace(str, "/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ|u/g", "u");
            str = Regex.Replace(str, "/ỳ|ý|ỵ|ỷ|ỹ|y/g", "y");
            str = str.Replace("đ", "d");
            // Some system encode vietnamese combining accent as individual utf-8 characters
            str = Regex.Replace(str, "/\u0300|\u0301|\u0303|\u0309|\u0323/g", "");
            str = Regex.Replace(str, "/\u02C6|\u0306|\u031B/g", "");
            str = string.Join('-', str.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            return str;
        }
    }
}
