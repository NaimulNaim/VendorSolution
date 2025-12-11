using Ninject;
using SILDMS.DataAccess;
using SILDMS.DataAccess.AutoValueConf;
using SILDMS.DataAccess.AutoValueSetup;
using SILDMS.DataAccess.DashboardDataService;
using SILDMS.DataAccess.DashboardV2;
using SILDMS.DataAccess.DataLevelPermission;
using SILDMS.DataAccess.DataMigration;
using SILDMS.DataAccess.DefaultValueSetup;
using SILDMS.DataAccess.Departments;
using SILDMS.DataAccess.DocDestroy;
using SILDMS.DataAccess.DocumentCategory;
using SILDMS.DataAccess.DocumentType;
using SILDMS.DataAccess.FinancialQuotation;
using SILDMS.DataAccess.Menu;
using SILDMS.DataAccess.MultiDocScan;
using SILDMS.DataAccess.NavMenuOptSetup;
using SILDMS.DataAccess.OriginalDocSearching;
using SILDMS.DataAccess.Owner;
using SILDMS.DataAccess.OwnerLevel;
using SILDMS.DataAccess.OwnerLevelPermission;
using SILDMS.DataAccess.OwnerProperIdentity;
using SILDMS.DataAccess.OwnerProperty;
using SILDMS.DataAccess.Reports;
using SILDMS.DataAccess.ResendFailedSmsEmail;
using SILDMS.DataAccess.RoleMenuPermission;
using SILDMS.DataAccess.Roles;
using SILDMS.DataAccess.RoleSetup;
using SILDMS.DataAccess.Server;
using SILDMS.DataAccess.TechnicalQuotation;
using SILDMS.DataAccess.UserAccessLog;
using SILDMS.DataAccess.UserDoctypeMap;
using SILDMS.DataAccess.UserLevel;
using SILDMS.DataAccess.Users;
using SILDMS.DataAccess.VendorDashboardV2;
using SILDMS.DataAccess.VendorRegistration;
using SILDMS.DataAccess.VendorRegistrationUpdate;
using SILDMS.DataAccess.VersionDocSearching;
using SILDMS.DataAccess.VersioningOfOriginalDoc;
using SILDMS.DataAccess.VersioningVersionedDoc;
using SILDMS.DataAccessInterface;
using SILDMS.DataAccessInterface.AutoValueConf;
using SILDMS.DataAccessInterface.AutoValueSetup;
using SILDMS.DataAccessInterface.DashboardDataService;
using SILDMS.DataAccessInterface.DashboardV2;
using SILDMS.DataAccessInterface.DataLevelPermission;
using SILDMS.DataAccessInterface.DataMigration;
using SILDMS.DataAccessInterface.DefaultValueSetup;
using SILDMS.DataAccessInterface.Departments;
using SILDMS.DataAccessInterface.DocDestroy;
using SILDMS.DataAccessInterface.DocumentCategory;
using SILDMS.DataAccessInterface.DocumentType;
using SILDMS.DataAccessInterface.Menu;
using SILDMS.DataAccessInterface.MultiDocScan;
using SILDMS.DataAccessInterface.NavMenuOptSetup;
using SILDMS.DataAccessInterface.OriginalDocSearching;
using SILDMS.DataAccessInterface.Owner;
using SILDMS.DataAccessInterface.OwnerLevel;
using SILDMS.DataAccessInterface.OwnerLevelPermission;
using SILDMS.DataAccessInterface.OwnerProperIdentity;
using SILDMS.DataAccessInterface.OwnerProperty;
using SILDMS.DataAccessInterface.Reports;
using SILDMS.DataAccessInterface.ResendFailedSmsEmail;
using SILDMS.DataAccessInterface.RoleMenuPermission;
using SILDMS.DataAccessInterface.Roles;
using SILDMS.DataAccessInterface.RoleSetup;
using SILDMS.DataAccessInterface.Server;
using SILDMS.DataAccessInterface.UserAccessLog;
using SILDMS.DataAccessInterface.UserDoctypeMap;
using SILDMS.DataAccessInterface.UserLevel;
using SILDMS.DataAccessInterface.Users;
using SILDMS.DataAccessInterface.VendorDashboard;
using SILDMS.DataAccessInterface.VersionDocSearching;
using SILDMS.DataAccessInterface.VersioningOfOriginalDoc;
using SILDMS.DataAccessInterface.VersioningVersionedDoc;
using SILDMS.Service;
using SILDMS.Service.AutoValueConf;
using SILDMS.Service.AutoValueSetup;
using SILDMS.Service.Dashboard;
using SILDMS.Service.DashboardV2;
using SILDMS.Service.DataLevelPermission;
using SILDMS.Service.DataMigration;
using SILDMS.Service.DefaultValueSetup;
using SILDMS.Service.Departments;
using SILDMS.Service.DocDestroy;
using SILDMS.Service.DocDestroyPolicy;
using SILDMS.Service.DocProperty;
using SILDMS.Service.DocumentCategory;
using SILDMS.Service.DocumentType;
using SILDMS.Service.FinancialQuotation;
using SILDMS.Service.Menu;
using SILDMS.Service.MultiDocScan;
using SILDMS.Service.NavMenuOptSetup;
using SILDMS.Service.OriginalDocSearching;
using SILDMS.Service.Owner;
using SILDMS.Service.OwnerLevel;
using SILDMS.Service.OwnerLevelPermission;
using SILDMS.Service.OwnerProperIdentity;
using SILDMS.Service.Reports;
using SILDMS.Service.ResendFailedSmsEmail;
using SILDMS.Service.RoleMenuPermission;
using SILDMS.Service.Roles;
using SILDMS.Service.RoleSetup;
using SILDMS.Service.Server;
using SILDMS.Service.TechnicalQuotation;
using SILDMS.Service.UserAccessLog;
using SILDMS.Service.UserDoctypeMap;
using SILDMS.Service.UserLevel;
using SILDMS.Service.Users;
using SILDMS.Service.VendorDashboard;
using SILDMS.Service.VendorRegistration;
using SILDMS.Service.VendorRegistrationUpdate;
using SILDMS.Service.VersionDocSearching;
using SILDMS.Service.VersioningOfOriginalDoc;
using SILDMS.Service.VersioningVersionedDoc;
using SILDMS.Utillity.Localization;

namespace SILDMS.InfraStructure
{
    public class ServiceRegistration
    {
        internal void Load(IKernel kernel)
        {
            kernel.Bind<ILocalizationService>().To<LocalizationService>();

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IUserDataService>().To<UserDataService>();

            kernel.Bind<IMenuService>().To<MenuService>();
            kernel.Bind<IMenuDataService>().To<MenuDataService>();

            kernel.Bind<IDepartmentService>().To<DepartmentService>();
            kernel.Bind<IDepartmentDataService>().To<DepartmentDataService>();

            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IRoleDataService>().To<RoleDataService>();

            kernel.Bind<IOwnerProperIdentityService>().To<OwnerProperIdentityService>();
            kernel.Bind<IOwnerProperIdentityDataService>().To<OwnerProperIdentityDataService>();

            kernel.Bind<IOwnerLevelService>().To<OwnerLevelService>();
            kernel.Bind<IOwnerLevelDataService>().To<OwnerLevelDataService>();

            kernel.Bind<IOwnerService>().To<OwnerService>();
            kernel.Bind<IOwnerDataService>().To<OwnerDataService>();

            kernel.Bind<IDocCategoryService>().To<DocCategoryService>();
            kernel.Bind<IDocCategoryDataService>().To<DocCategoryDataService>();

            kernel.Bind<IDocTypeService>().To<DocTypeService>();
            kernel.Bind<IDocTypeDataService>().To<DocTypeDataService>();

            kernel.Bind<IDocPropertyService>().To<DocPropertyService>();
            kernel.Bind<IDocPropertyDataService>().To<DocPropertyDataService>();

            kernel.Bind<IMultiDocScanService>().To<MultiDocScanService>();
            kernel.Bind<IMultiDocScanDataService>().To<MultiDocScanDataService>();

            kernel.Bind<IRoleSetupService>().To<RoleSetupService>();
            kernel.Bind<IRoleSetupDataService>().To<RoleSetupDataService>();

            kernel.Bind<INavMenuOptSetupService>().To<NavMenuOptSetupService>();
            kernel.Bind<INavMenuOptSetupDataService>().To<NavMenuOptSetupDataService>();

            kernel.Bind<IRoleMenuPermissionService>().To<RoleMenuPermissionService>();
            kernel.Bind<IRoleMenuPermissionDataService>().To<RoleMenuPermissionDataService>();

            kernel.Bind<IOwnerLevelPermissionService>().To<OwnerLevelPermissionService>();
            kernel.Bind<IOwnerLevelPermissionDataService>().To<OwnerLevelPermissionDataService>();

            kernel.Bind<IDataLevelPermissionService>().To<DataLevelPermissionService>();
            kernel.Bind<IDataLevelPermissionDataService>().To<DataLevelPermissionDataService>();

            kernel.Bind<IUserLevelService>().To<UserLevelService>();
            kernel.Bind<IUserLevelDataService>().To<UserLevelDataService>();

            kernel.Bind<IUserAccessLogService>().To<UserAccessLogService>();
            kernel.Bind<IUserAccessLogDataService>().To<UserAccessLogDataService>();

            kernel.Bind<IServerService>().To<ServerService>();
            kernel.Bind<IServerDataService>().To<ServerDataService>();

            kernel.Bind<IOriginalDocSearchingService>().To<OriginalDocSearchingService>();
            kernel.Bind<IOriginalDocSearchingDataService>().To<OriginalDocSearchingDataService>();

            kernel.Bind<IVersionDocSearchingDataService>().To<VersionDocSearchingDataService>();
            kernel.Bind<IVersionDocSearchingService>().To<VersionDocSearchingService>();

            kernel.Bind<IVersioningOfOriginalDocService>().To<VersioningOfOriginalDocService>();
            kernel.Bind<IVersioningOfOriginalDocDataService>().To<VersioningOfOriginalDocDataService>();

            kernel.Bind<IVersioningVersionedDocDataService>().To<VersioningVersionedDocDataService>();
            kernel.Bind<IVersioningVersionedDocService>().To<VersioningVersionedDocService>();

            kernel.Bind<IDashboardDataService>().To<DashboardDataService>();
            kernel.Bind<IDashboardService>().To<DashboardService>();

            kernel.Bind<IDocDestroyPolicyService>().To<DocDestroyPolicyService>();
            kernel.Bind<IDocDestroyPolicyDataService>().To<DocDestroyPolicyDataService>();

            kernel.Bind<IDocDestroyService>().To<DocDestroyService>();
            kernel.Bind<IDocDestroyDataService>().To<DocDestroyDataService>();

            kernel.Bind<IDefaultValueSetupDataService>().To<DefaultValueSetupDataService>();
            kernel.Bind<IDefalutValueSetupService>().To<DefaultValueSetupService>();

            kernel.Bind<IAutoValueConfService>().To<AutoValueConfService>();
            kernel.Bind<IAutoValueConfDataService>().To<AutoValueConfDataService>();

            kernel.Bind<IAutoValueSetupService>().To<AutoValueSetupService>();
            kernel.Bind<IAutoValueSetupDataService>().To<AutoValueSetupDataService>();
            kernel.Bind<IReportsDataService>().To<ReportsDataService>();
            kernel.Bind<IReportsService>().To<ReportsService>();

            kernel.Bind<IDashboardV2Service>().To<DashboardV2Service>();
            kernel.Bind<IDashboardV2DataService>().To<DashboardV2DataService>();

            kernel.Bind<IUserDoctypeMapService>().To<UserDoctypeMapService>();
            kernel.Bind<IUserDoctypeMapDataService>().To<UserDoctypeMapDataService>();

            kernel.Bind<IDataMigrationService>().To<DataMigrationService>();
            kernel.Bind<IDataMigrationDataService>().To<DataMigrationDataService>();

            kernel.Bind<IResendFailedSmsEmailService>().To<ResendFailedSmsEmailService>();
            kernel.Bind<IResendFailedSmsEmailDataService>().To<ResendFailedSmsEmailDataService>();

            kernel.Bind<ITechnicalQuotationData>().To<TechnicalQuotationData>();
            kernel.Bind<ITechnicalQuotationService>().To<TechnicalQuotationService>();

            kernel.Bind<IFinancialQuotationData>().To<FinancialQuotationData>();
            kernel.Bind<IFinancialQuotationService>().To<FinancialQuotationService>();

            kernel.Bind<IVendorRegistrationDataService>().To<VendorRegistrationDataService>();
            kernel.Bind<IVendorRegistrationService>().To<VendorRegistrationService>();

            kernel.Bind<IVendorRegistrationUpdateData>().To<VendorRegistrationUpdateData>();
            kernel.Bind<IVendorRegistrationUpdateService>().To<VendorRegistrationUpdateService>();

            kernel.Bind<IVendorDashboardV2Service>().To<VendorDashboardV2Service>();
            kernel.Bind<IVendorDashboardV2DataService>().To<VendorDashboardV2DataService>();


        }
    }
}
 