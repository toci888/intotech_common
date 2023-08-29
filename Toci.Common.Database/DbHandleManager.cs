﻿using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Database
{
    public class DbHandleManager<TModel> : DbContext, IDbHandleManager<TModel>, IDbContextFactory<DbContext> where TModel : ModelBase
    {
        private Func<DbContext> databaseHandle;

        public DbHandleManager(Func<DbContext> databaseHandle)
        {
            this.databaseHandle = databaseHandle;
        }
        public DbHandleManager(Func<DbContext> databaseHandle, DbHandleType type)
        {
            //this.GetInstance(type);
        }

        public DbContext CreateDbContext()
        {
            return this;
        }

        //public override Assembly Assembly => throw new NotImplementedException();

        //public override string? AssemblyQualifiedName => throw new NotImplementedException();

        //public override Type? BaseType => throw new NotImplementedException();

        //public override string? FullName => throw new NotImplementedException();

        //public override Guid GUID => throw new NotImplementedException();

        //public override Module Module => throw new NotImplementedException();

        //public override string? Namespace => throw new NotImplementedException();

        //public override Type UnderlyingSystemType => typeof(DbHandleManager<TModel>);

        //public override string Name => throw new NotImplementedException();

        //public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr)
        //{
        //    throw new NotImplementedException();
        //}

        //public override object[] GetCustomAttributes(bool inherit)
        //{
        //    throw new NotImplementedException();
        //}

        //public override object[] GetCustomAttributes(Type attributeType, bool inherit)
        //{
        //    throw new NotImplementedException();
        //}

        //public override Type? GetElementType()
        //{
        //    throw new NotImplementedException();
        //}

        //public override EventInfo? GetEvent(string name, BindingFlags bindingAttr)
        //{
        //    throw new NotImplementedException();
        //}

        //public override EventInfo[] GetEvents(BindingFlags bindingAttr)
        //{
        //    throw new NotImplementedException();
        //}

        //public override FieldInfo? GetField(string name, BindingFlags bindingAttr)
        //{
        //    throw new NotImplementedException();
        //}

        //public override FieldInfo[] GetFields(BindingFlags bindingAttr)
        //{
        //    throw new NotImplementedException();
        //}

        public virtual IDbHandle<TModel> GetInstance(DbHandleType dbHandleType, Func<DbContext> databaseHandle)
        {
            if (dbHandleType == DbHandleType.TypeSc)
            {
                return new DbHandleCriticalSection<TModel>(databaseHandle, DbHandleType.TypeSc);
            }

            return new DbHandleMultiThreading<TModel>(databaseHandle);
        }

        public IDbHandle<TModel> GetInstance(Func<DbContext> databaseHandle, DbHandleType dbHandleType)
        {
            return GetInstance(dbHandleType, databaseHandle);
        }

        public IDbHandle<TModel> GetInstance(DbHandleType dbHandleType)
        {
            throw new NotImplementedException();
        }

        //[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.Interfaces)]
        //public override Type? GetInterface(string name, bool ignoreCase)
        //{
        //    throw new NotImplementedException();
        //}

        //public override Type[] GetInterfaces()
        //{
        //    throw new NotImplementedException();
        //}

        //public override MemberInfo[] GetMembers(BindingFlags bindingAttr)
        //{
        //    throw new NotImplementedException();
        //}

        //public override MethodInfo[] GetMethods(BindingFlags bindingAttr)
        //{
        //    throw new NotImplementedException();
        //}

        //public override Type? GetNestedType(string name, BindingFlags bindingAttr)
        //{
        //    throw new NotImplementedException();
        //}

        //public override Type[] GetNestedTypes(BindingFlags bindingAttr)
        //{
        //    throw new NotImplementedException();
        //}

        //public override PropertyInfo[] GetProperties(BindingFlags bindingAttr)
        //{
        //    throw new NotImplementedException();
        //}

        //public override object? InvokeMember(string name, BindingFlags invokeAttr, Binder? binder, object? target, object?[]? args, ParameterModifier[]? modifiers, CultureInfo? culture, string[]? namedParameters)
        //{
        //    throw new NotImplementedException();
        //}

        //public override bool IsDefined(Type attributeType, bool inherit)
        //{
        //    throw new NotImplementedException();
        //}

        //protected override TypeAttributes GetAttributeFlagsImpl()
        //{
        //    return TypeAttributes.Public;
        //}

        //protected override ConstructorInfo? GetConstructorImpl(BindingFlags bindingAttr, Binder? binder, CallingConventions callConvention, Type[] types, ParameterModifier[]? modifiers)
        //{
        //    throw new NotImplementedException();
        //}

        //protected override MethodInfo? GetMethodImpl(string name, BindingFlags bindingAttr, Binder? binder, CallingConventions callConvention, Type[]? types, ParameterModifier[]? modifiers)
        //{
        //    throw new NotImplementedException();
        //}

        //protected override PropertyInfo? GetPropertyImpl(string name, BindingFlags bindingAttr, Binder? binder, Type? returnType, Type[]? types, ParameterModifier[]? modifiers)
        //{
        //    throw new NotImplementedException();
        //}

        //protected override bool HasElementTypeImpl()
        //{
        //    throw new NotImplementedException();
        //}

        //protected override bool IsArrayImpl()
        //{
        //    throw new NotImplementedException();
        //}

        //protected override bool IsByRefImpl()
        //{
        //    throw new NotImplementedException();
        //}

        //protected override bool IsCOMObjectImpl()
        //{
        //    throw new NotImplementedException();
        //}

        //protected override bool IsPointerImpl()
        //{
        //    throw new NotImplementedException();
        //}

        //protected override bool IsPrimitiveImpl()
        //{
        //    throw new NotImplementedException();
        //}

    }
}
