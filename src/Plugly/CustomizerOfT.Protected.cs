using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Plugly
{
    public sealed partial class Customizer<TTarget>
    {
        #region Func registrations

        /// <summary>
        /// Registers an override for the specified protected method with a return value which takes no arguments.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="TResult">The type of the method result.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override function which accepts the target as an argument and returns <typeparamref name="TResult"/>.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, TResult>(
            Expression<Func<TDerivedClass, TResult>> method,
            Expression<Func<TDerivedClass, TResult>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected method with a return value.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="TResult">The type of the method result.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override function which accepts the target as a first argument, the original method arguments after and returns <typeparamref name="TResult"/>.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, TResult>(
            Expression<Func<TDerivedClass, TResult>> method,
            Expression<Func<TDerivedClass, T1, TResult>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected method with a return value.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="TResult">The type of the method result.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override function which accepts the target as a first argument, the original method arguments after and returns <typeparamref name="TResult"/>.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, TResult>(
            Expression<Func<TDerivedClass, TResult>> method,
            Expression<Func<TDerivedClass, T1, T2, TResult>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected method with a return value.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="T3">The 3rd argument type.</typeparam>
        /// <typeparam name="TResult">The type of the method result.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override function which accepts the target as a first argument, the original method arguments after and returns <typeparamref name="TResult"/>.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, T3, TResult>(
                    Expression<Func<TDerivedClass, TResult>> method,
                    Expression<Func<TDerivedClass, T1, T2, T3, TResult>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected method with a return value.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="T3">The 3rd argument type.</typeparam>
        /// <typeparam name="T4">The 4th argument type.</typeparam>
        /// <typeparam name="TResult">The type of the method result.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override function which accepts the target as a first argument, the original method arguments after and returns <typeparamref name="TResult"/>.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, T3, T4, TResult>(
                    Expression<Func<TDerivedClass, TResult>> method,
                    Expression<Func<TDerivedClass, T1, T2, T3, T4, TResult>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected method with a return value.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="T3">The 3rd argument type.</typeparam>
        /// <typeparam name="T4">The 4th argument type.</typeparam>
        /// <typeparam name="T5">The 5th argument type.</typeparam>
        /// <typeparam name="TResult">The type of the method result.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override function which accepts the target as a first argument, the original method arguments after and returns <typeparamref name="TResult"/>.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, T3, T4, T5, TResult>(
                    Expression<Func<TDerivedClass, TResult>> method,
                    Expression<Func<TDerivedClass, T1, T2, T3, T4, T5, TResult>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected method with a return value.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="T3">The 3rd argument type.</typeparam>
        /// <typeparam name="T4">The 4th argument type.</typeparam>
        /// <typeparam name="T5">The 5th argument type.</typeparam>
        /// <typeparam name="T6">The 6th argument type.</typeparam>
        /// <typeparam name="TResult">The type of the method result.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override function which accepts the target as a first argument, the original method arguments after and returns <typeparamref name="TResult"/>.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, T3, T4, T5, T6, TResult>(
                    Expression<Func<TDerivedClass, TResult>> method,
                    Expression<Func<TDerivedClass, T1, T2, T3, T4, T5, T6, TResult>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected method with a return value.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="T3">The 3rd argument type.</typeparam>
        /// <typeparam name="T4">The 4th argument type.</typeparam>
        /// <typeparam name="T5">The 5th argument type.</typeparam>
        /// <typeparam name="T6">The 6th argument type.</typeparam>
        /// <typeparam name="T7">The 7th argument type.</typeparam>
        /// <typeparam name="TResult">The type of the method result.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override function which accepts the target as a first argument, the original method arguments after and returns <typeparamref name="TResult"/>.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, TResult>(
                    Expression<Func<TDerivedClass, TResult>> method,
                    Expression<Func<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, TResult>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected method with a return value.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="T3">The 3rd argument type.</typeparam>
        /// <typeparam name="T4">The 4th argument type.</typeparam>
        /// <typeparam name="T5">The 5th argument type.</typeparam>
        /// <typeparam name="T6">The 6th argument type.</typeparam>
        /// <typeparam name="T7">The 7th argument type.</typeparam>
        /// <typeparam name="T8">The 8th argument type.</typeparam>
        /// <typeparam name="TResult">The type of the method result.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override function which accepts the target as a first argument, the original method arguments after and returns <typeparamref name="TResult"/>.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
                    Expression<Func<TDerivedClass, TResult>> method,
                    Expression<Func<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, TResult>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected method with a return value.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="T3">The 3rd argument type.</typeparam>
        /// <typeparam name="T4">The 4th argument type.</typeparam>
        /// <typeparam name="T5">The 5th argument type.</typeparam>
        /// <typeparam name="T6">The 6th argument type.</typeparam>
        /// <typeparam name="T7">The 7th argument type.</typeparam>
        /// <typeparam name="T8">The 8th argument type.</typeparam>
        /// <typeparam name="T9">The 9th argument type.</typeparam>
        /// <typeparam name="TResult">The type of the method result.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override function which accepts the target as a first argument, the original method arguments after and returns <typeparamref name="TResult"/>.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
                    Expression<Func<TDerivedClass, TResult>> method,
                    Expression<Func<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected method with a return value.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="T3">The 3rd argument type.</typeparam>
        /// <typeparam name="T4">The 4th argument type.</typeparam>
        /// <typeparam name="T5">The 5th argument type.</typeparam>
        /// <typeparam name="T6">The 6th argument type.</typeparam>
        /// <typeparam name="T7">The 7th argument type.</typeparam>
        /// <typeparam name="T8">The 8th argument type.</typeparam>
        /// <typeparam name="T9">The 9th argument type.</typeparam>
        /// <typeparam name="T10">The 10th argument type.</typeparam>
        /// <typeparam name="TResult">The type of the method result.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override function which accepts the target as a first argument, the original method arguments after and returns <typeparamref name="TResult"/>.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
                    Expression<Func<TDerivedClass, TResult>> method,
                    Expression<Func<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected method with a return value.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="T3">The 3rd argument type.</typeparam>
        /// <typeparam name="T4">The 4th argument type.</typeparam>
        /// <typeparam name="T5">The 5th argument type.</typeparam>
        /// <typeparam name="T6">The 6th argument type.</typeparam>
        /// <typeparam name="T7">The 7th argument type.</typeparam>
        /// <typeparam name="T8">The 8th argument type.</typeparam>
        /// <typeparam name="T9">The 9th argument type.</typeparam>
        /// <typeparam name="T10">The 10th argument type.</typeparam>
        /// <typeparam name="T11">The 11th argument type.</typeparam>
        /// <typeparam name="TResult">The type of the method result.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override function which accepts the target as a first argument, the original method arguments after and returns <typeparamref name="TResult"/>.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
                    Expression<Func<TDerivedClass, TResult>> method,
                    Expression<Func<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected method with a return value.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="T3">The 3rd argument type.</typeparam>
        /// <typeparam name="T4">The 4th argument type.</typeparam>
        /// <typeparam name="T5">The 5th argument type.</typeparam>
        /// <typeparam name="T6">The 6th argument type.</typeparam>
        /// <typeparam name="T7">The 7th argument type.</typeparam>
        /// <typeparam name="T8">The 8th argument type.</typeparam>
        /// <typeparam name="T9">The 9th argument type.</typeparam>
        /// <typeparam name="T10">The 10th argument type.</typeparam>
        /// <typeparam name="T11">The 11th argument type.</typeparam>
        /// <typeparam name="T12">The 12th argument type.</typeparam>
        /// <typeparam name="TResult">The type of the method result.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override function which accepts the target as a first argument, the original method arguments after and returns <typeparamref name="TResult"/>.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
                    Expression<Func<TDerivedClass, TResult>> method,
                    Expression<Func<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected method with a return value.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="T3">The 3rd argument type.</typeparam>
        /// <typeparam name="T4">The 4th argument type.</typeparam>
        /// <typeparam name="T5">The 5th argument type.</typeparam>
        /// <typeparam name="T6">The 6th argument type.</typeparam>
        /// <typeparam name="T7">The 7th argument type.</typeparam>
        /// <typeparam name="T8">The 8th argument type.</typeparam>
        /// <typeparam name="T9">The 9th argument type.</typeparam>
        /// <typeparam name="T10">The 10th argument type.</typeparam>
        /// <typeparam name="T11">The 11th argument type.</typeparam>
        /// <typeparam name="T12">The 12th argument type.</typeparam>
        /// <typeparam name="T13">The 13th argument type.</typeparam>
        /// <typeparam name="TResult">The type of the method result.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override function which accepts the target as a first argument, the original method arguments after and returns <typeparamref name="TResult"/>.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
                    Expression<Func<TDerivedClass, TResult>> method,
                    Expression<Func<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected method with a return value.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="T3">The 3rd argument type.</typeparam>
        /// <typeparam name="T4">The 4th argument type.</typeparam>
        /// <typeparam name="T5">The 5th argument type.</typeparam>
        /// <typeparam name="T6">The 6th argument type.</typeparam>
        /// <typeparam name="T7">The 7th argument type.</typeparam>
        /// <typeparam name="T8">The 8th argument type.</typeparam>
        /// <typeparam name="T9">The 9th argument type.</typeparam>
        /// <typeparam name="T10">The 10th argument type.</typeparam>
        /// <typeparam name="T11">The 11th argument type.</typeparam>
        /// <typeparam name="T12">The 12th argument type.</typeparam>
        /// <typeparam name="T13">The 13th argument type.</typeparam>
        /// <typeparam name="T14">The 14th argument type.</typeparam>
        /// <typeparam name="TResult">The type of the method result.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override function which accepts the target as a first argument, the original method arguments after and returns <typeparamref name="TResult"/>.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
                    Expression<Func<TDerivedClass, TResult>> method,
                    Expression<Func<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected method with a return value.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="T3">The 3rd argument type.</typeparam>
        /// <typeparam name="T4">The 4th argument type.</typeparam>
        /// <typeparam name="T5">The 5th argument type.</typeparam>
        /// <typeparam name="T6">The 6th argument type.</typeparam>
        /// <typeparam name="T7">The 7th argument type.</typeparam>
        /// <typeparam name="T8">The 8th argument type.</typeparam>
        /// <typeparam name="T9">The 9th argument type.</typeparam>
        /// <typeparam name="T10">The 10th argument type.</typeparam>
        /// <typeparam name="T11">The 11th argument type.</typeparam>
        /// <typeparam name="T12">The 12th argument type.</typeparam>
        /// <typeparam name="T13">The 13th argument type.</typeparam>
        /// <typeparam name="T14">The 14th argument type.</typeparam>
        /// <typeparam name="T15">The 15th argument type.</typeparam>
        /// <typeparam name="TResult">The type of the method result.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override function which accepts the target as a first argument, the original method arguments after and returns <typeparamref name="TResult"/>.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
            Expression<Func<TDerivedClass, TResult>> method,
            Expression<Func<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        #endregion

        #region Action registrations

        /// <summary>
        /// Registers an override for the specified protected void method which takes no arguments.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override action which accepts the target as an argument.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass>(
            Expression<Action<TDerivedClass>> method,
            Expression<Action<TDerivedClass>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected void method.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override action which accepts the target as a first argument and the original method arguments after.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1>(
            Expression<Action<TDerivedClass>> method,
            Expression<Action<TDerivedClass, T1>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected void method.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override action which accepts the target as a first argument and the original method arguments after.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2>(
            Expression<Action<TDerivedClass>> method,
            Expression<Action<TDerivedClass, T1, T2>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected void method.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="T3">The 3rd argument type.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override action which accepts the target as a first argument and the original method arguments after.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, T3>(
                    Expression<Action<TDerivedClass>> method,
                    Expression<Action<TDerivedClass, T1, T2, T3>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected void method.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="T3">The 3rd argument type.</typeparam>
        /// <typeparam name="T4">The 4th argument type.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override action which accepts the target as a first argument and the original method arguments after.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, T3, T4>(
                    Expression<Action<TDerivedClass>> method,
                    Expression<Action<TDerivedClass, T1, T2, T3, T4>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected void method.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="T3">The 3rd argument type.</typeparam>
        /// <typeparam name="T4">The 4th argument type.</typeparam>
        /// <typeparam name="T5">The 5th argument type.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override action which accepts the target as a first argument and the original method arguments after.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, T3, T4, T5>(
                    Expression<Action<TDerivedClass>> method,
                    Expression<Action<TDerivedClass, T1, T2, T3, T4, T5>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected void method.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="T3">The 3rd argument type.</typeparam>
        /// <typeparam name="T4">The 4th argument type.</typeparam>
        /// <typeparam name="T5">The 5th argument type.</typeparam>
        /// <typeparam name="T6">The 6th argument type.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override action which accepts the target as a first argument and the original method arguments after.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, T3, T4, T5, T6>(
                    Expression<Action<TDerivedClass>> method,
                    Expression<Action<TDerivedClass, T1, T2, T3, T4, T5, T6>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected void method.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="T3">The 3rd argument type.</typeparam>
        /// <typeparam name="T4">The 4th argument type.</typeparam>
        /// <typeparam name="T5">The 5th argument type.</typeparam>
        /// <typeparam name="T6">The 6th argument type.</typeparam>
        /// <typeparam name="T7">The 7th argument type.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override action which accepts the target as a first argument and the original method arguments after.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, T3, T4, T5, T6, T7>(
                    Expression<Action<TDerivedClass>> method,
                    Expression<Action<TDerivedClass, T1, T2, T3, T4, T5, T6, T7>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected void method.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="T3">The 3rd argument type.</typeparam>
        /// <typeparam name="T4">The 4th argument type.</typeparam>
        /// <typeparam name="T5">The 5th argument type.</typeparam>
        /// <typeparam name="T6">The 6th argument type.</typeparam>
        /// <typeparam name="T7">The 7th argument type.</typeparam>
        /// <typeparam name="T8">The 8th argument type.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override action which accepts the target as a first argument and the original method arguments after.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8>(
                    Expression<Action<TDerivedClass>> method,
                    Expression<Action<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected void method.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="T3">The 3rd argument type.</typeparam>
        /// <typeparam name="T4">The 4th argument type.</typeparam>
        /// <typeparam name="T5">The 5th argument type.</typeparam>
        /// <typeparam name="T6">The 6th argument type.</typeparam>
        /// <typeparam name="T7">The 7th argument type.</typeparam>
        /// <typeparam name="T8">The 8th argument type.</typeparam>
        /// <typeparam name="T9">The 9th argument type.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override action which accepts the target as a first argument and the original method arguments after.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
                    Expression<Action<TDerivedClass>> method,
                    Expression<Action<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected void method.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="T3">The 3rd argument type.</typeparam>
        /// <typeparam name="T4">The 4th argument type.</typeparam>
        /// <typeparam name="T5">The 5th argument type.</typeparam>
        /// <typeparam name="T6">The 6th argument type.</typeparam>
        /// <typeparam name="T7">The 7th argument type.</typeparam>
        /// <typeparam name="T8">The 8th argument type.</typeparam>
        /// <typeparam name="T9">The 9th argument type.</typeparam>
        /// <typeparam name="T10">The 10th argument type.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override action which accepts the target as a first argument and the original method arguments after.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
                    Expression<Action<TDerivedClass>> method,
                    Expression<Action<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected void method.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="T3">The 3rd argument type.</typeparam>
        /// <typeparam name="T4">The 4th argument type.</typeparam>
        /// <typeparam name="T5">The 5th argument type.</typeparam>
        /// <typeparam name="T6">The 6th argument type.</typeparam>
        /// <typeparam name="T7">The 7th argument type.</typeparam>
        /// <typeparam name="T8">The 8th argument type.</typeparam>
        /// <typeparam name="T9">The 9th argument type.</typeparam>
        /// <typeparam name="T10">The 10th argument type.</typeparam>
        /// <typeparam name="T11">The 11th argument type.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override action which accepts the target as a first argument and the original method arguments after.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
                    Expression<Action<TDerivedClass>> method,
                    Expression<Action<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected void method.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="T3">The 3rd argument type.</typeparam>
        /// <typeparam name="T4">The 4th argument type.</typeparam>
        /// <typeparam name="T5">The 5th argument type.</typeparam>
        /// <typeparam name="T6">The 6th argument type.</typeparam>
        /// <typeparam name="T7">The 7th argument type.</typeparam>
        /// <typeparam name="T8">The 8th argument type.</typeparam>
        /// <typeparam name="T9">The 9th argument type.</typeparam>
        /// <typeparam name="T10">The 10th argument type.</typeparam>
        /// <typeparam name="T11">The 11th argument type.</typeparam>
        /// <typeparam name="T12">The 12th argument type.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override action which accepts the target as a first argument and the original method arguments after.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
                    Expression<Action<TDerivedClass>> method,
                    Expression<Action<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected void method.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="T3">The 3rd argument type.</typeparam>
        /// <typeparam name="T4">The 4th argument type.</typeparam>
        /// <typeparam name="T5">The 5th argument type.</typeparam>
        /// <typeparam name="T6">The 6th argument type.</typeparam>
        /// <typeparam name="T7">The 7th argument type.</typeparam>
        /// <typeparam name="T8">The 8th argument type.</typeparam>
        /// <typeparam name="T9">The 9th argument type.</typeparam>
        /// <typeparam name="T10">The 10th argument type.</typeparam>
        /// <typeparam name="T11">The 11th argument type.</typeparam>
        /// <typeparam name="T12">The 12th argument type.</typeparam>
        /// <typeparam name="T13">The 13th argument type.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override action which accepts the target as a first argument and the original method arguments after.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
                    Expression<Action<TDerivedClass>> method,
                    Expression<Action<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected void method.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="T3">The 3rd argument type.</typeparam>
        /// <typeparam name="T4">The 4th argument type.</typeparam>
        /// <typeparam name="T5">The 5th argument type.</typeparam>
        /// <typeparam name="T6">The 6th argument type.</typeparam>
        /// <typeparam name="T7">The 7th argument type.</typeparam>
        /// <typeparam name="T8">The 8th argument type.</typeparam>
        /// <typeparam name="T9">The 9th argument type.</typeparam>
        /// <typeparam name="T10">The 10th argument type.</typeparam>
        /// <typeparam name="T11">The 11th argument type.</typeparam>
        /// <typeparam name="T12">The 12th argument type.</typeparam>
        /// <typeparam name="T13">The 13th argument type.</typeparam>
        /// <typeparam name="T14">The 14th argument type.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override action which accepts the target as a first argument and the original method arguments after.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
                    Expression<Action<TDerivedClass>> method,
                    Expression<Action<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        /// <summary>
        /// Registers an override for the specified protected void method.
        /// </summary>
        /// <typeparam name="TDerivedClass">The type derived from <typeparamref name="TTarget"/>.</typeparam>
        /// <typeparam name="T1">The 1st argument type.</typeparam>
        /// <typeparam name="T2">The 2nd argument type.</typeparam>
        /// <typeparam name="T3">The 3rd argument type.</typeparam>
        /// <typeparam name="T4">The 4th argument type.</typeparam>
        /// <typeparam name="T5">The 5th argument type.</typeparam>
        /// <typeparam name="T6">The 6th argument type.</typeparam>
        /// <typeparam name="T7">The 7th argument type.</typeparam>
        /// <typeparam name="T8">The 8th argument type.</typeparam>
        /// <typeparam name="T9">The 9th argument type.</typeparam>
        /// <typeparam name="T10">The 10th argument type.</typeparam>
        /// <typeparam name="T11">The 11th argument type.</typeparam>
        /// <typeparam name="T12">The 12th argument type.</typeparam>
        /// <typeparam name="T13">The 13th argument type.</typeparam>
        /// <typeparam name="T14">The 14th argument type.</typeparam>
        /// <typeparam name="T15">The 15th argument type.</typeparam>
        /// <param name="method">The expression of the method call.</param>
        /// <param name="with">The override action which accepts the target as a first argument and the original method arguments after.</param>
        /// <returns>Returns self instance.</returns>
        public Customizer<TTarget> OverrideProtected<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            Expression<Action<TDerivedClass>> method,
            Expression<Action<TDerivedClass, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> with)
        {
            config.Add<TTarget>(targetType, GetMethod(method), LinqHelper.RemapCalls(typeof(TDerivedClass), targetType, with)); return this;
        }

        #endregion
    }
}
