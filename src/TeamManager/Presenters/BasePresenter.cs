﻿using log4net;
using TeamManager.Database;
using TeamManager.Models.Logic;
using TeamManager.Models.Strategy;
using TeamManager.Presenters.Events;
using TeamManager.Utilities;

namespace TeamManager.Presenters
{
    /// <summary>
    /// The <see cref="BasePresenter"/> will contain the <see cref="IStrategy"/> interface that will be used for 
    /// retrieving data from the database.
    /// It also contains common data to share between all presenters.
    /// </summary>
    public abstract class BasePresenter
    {
        /// <summary> The <see cref="IStrategy"/> instance that will be used for retrieving data from the database. </summary>
        protected static IBusinessLogic BusinessLogic;

        /// <summary> Logger instance of the class <see cref="BasePresenter"/> </summary>
        private static readonly ILog Log = Logger.GetLogger();

        /// <summary> The shared event definition that gets invoked every time a child window is closed. </summary>
        protected static event PresenterHandler ChildClosed;


        /// <summary>
        /// The method that gets called when a child windows wanting to invoke the <see cref="ChildClosed"/> event in 
        /// order to notify all other presenters that inherit the <see cref="BasePresenter"/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnChildClosed(object sender, PresenterArgs e)
        {
            Log.Info($"Child window closed. Invoking ChildClosed => {e.Child}");
            ChildClosed?.Invoke(sender, e);
        }

        /// <summary> Abstract method that forces the inherited classess to implement in order to invoke the <see cref="ChildClosed"/> event. </summary>
        public abstract void WindowClosed();

        /// <summary>
        /// Initializes the <see cref="BusinessLogic"/> with the wanted <see cref="StrategyType"/> and <see cref="DatabaseType"/>.
        /// Note that this method gets triggered before the view gets initialized in <see cref="Program"/>.
        /// </summary>
        /// <param name="strategyType"></param>
        /// <param name="dbType"></param>
        public static void SetStrategyAndDatabaseType(BusinessLogicType blType, DatabaseType dbType, SortType sortType)
        {
            switch (blType)
            {
                case BusinessLogicType.Normal: @default:
                    BusinessLogic = new BusinessLogic(dbType, sortType);
                    break;

                case BusinessLogicType.MultiThreaded:
                    BusinessLogic = new BusinessLogicMt(dbType, sortType);
                    break;

                default:
                    goto @default;
            }

        }

    }
}
