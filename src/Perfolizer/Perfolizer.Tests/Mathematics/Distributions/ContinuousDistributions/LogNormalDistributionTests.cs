using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Perfolizer.Mathematics.Distributions.ContinuousDistributions;
using Perfolizer.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace Perfolizer.Tests.Mathematics.Distributions.ContinuousDistributions;

public class LogNormalDistributionTests : DistributionTestsBase
{
    protected override double Eps => 1e-4;

    public LogNormalDistributionTests(ITestOutputHelper output) : base(output)
    {
    }

    private static readonly double[] DefaultX =
    {
        0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1, 1.1, 1.2,
        1.3, 1.4, 1.5, 1.6, 1.7, 1.8, 1.9, 2, 2.1, 2.2, 2.3, 2.4, 2.5,
        2.6, 2.7, 2.8, 2.9, 3, 3.1, 3.2, 3.3, 3.4, 3.5, 3.6, 3.7, 3.8,
        3.9, 4, 4.1, 4.2, 4.3, 4.4, 4.5, 4.6, 4.7, 4.8, 4.9, 5
    };

    // We skip last quantile values because currently we don't have enough precision to estimate them without 1e-4 errors
    private static readonly double[] LogNormalDefaultProbs =
    {
        0, 0.01, 0.02, 0.03, 0.04, 0.05, 0.06, 0.07, 0.08, 0.09, 0.1,
        0.11, 0.12, 0.13, 0.14, 0.15, 0.16, 0.17, 0.18, 0.19, 0.2, 0.21,
        0.22, 0.23, 0.24, 0.25, 0.26, 0.27, 0.28, 0.29, 0.3, 0.31, 0.32,
        0.33, 0.34, 0.35, 0.36, 0.37, 0.38, 0.39, 0.4, 0.41, 0.42, 0.43,
        0.44, 0.45, 0.46, 0.47, 0.48, 0.49, 0.5, 0.51, 0.52, 0.53, 0.54,
        0.55, 0.56, 0.57, 0.58, 0.59, 0.6, 0.61, 0.62, 0.63, 0.64, 0.65,
        0.66, 0.67, 0.68, 0.69, 0.7, 0.71, 0.72, 0.73, 0.74, 0.75, 0.76,
        0.77, 0.78, 0.79, 0.8, 0.81, 0.82, 0.83, 0.84, 0.85, 0.86, 0.87,
        0.88, 0.89, 0.9, 0.91, 0.92, 0.93, 0.94, 0.95
    };

    private static readonly List<TestData> TestDataList = new()
    {
        new TestData(new LogNormalDistribution(),
            DefaultX,
            new[]
            {
                0, 0.281590189015268, 0.54626787075818, 0.6442032573592, 0.655444168060311,
                0.627496077115924, 0.583573822594504, 0.53479483207692, 0.486415781111553,
                0.440815685912027, 0.398942280401433, 0.36103126122904, 0.326972024074256,
                0.296496370636105, 0.269276228949933, 0.24497365171051, 0.223265447430299,
                0.203854259497871, 0.186472448538908, 0.170882238241215, 0.156874019278981,
                0.144263846343208, 0.132890686048187, 0.122613706931988, 0.113309753889709,
                0.10487106688965, 0.0972032590242929, 0.0902235455796965, 0.0838592045694877,
                0.0780462447216266, 0.0727282561399947, 0.0678554200108418, 0.0633836557708631,
                0.0592738865291035, 0.0554914059289083, 0.0520053318897058, 0.0487881347091861,
                0.045815228810908, 0.043064618993389, 0.0405165933905346, 0.0381534565118865,
                0.0359592967182337, 0.0339197833265838, 0.0320219892494392, 0.0302542356756332,
                0.0286059558101099, 0.0270675751221884, 0.0256304059181797, 0.0242865543650144,
                0.0230288383555034, 0.0218507148303272
            },
            new[]
            {
                0, 0.0106510993417001, 0.0537603104516631, 0.114300045049152,
                0.179757213895785, 0.244108595785583, 0.304736582510232, 0.360667582622649,
                0.411711891857455, 0.458044872785659, 0.5, 0.537965771424617,
                0.572334808836768, 0.603479689632152, 0.631742607836675, 0.657432169485154,
                0.680823787674827, 0.702161792699145, 0.721662252065085, 0.739515971034705,
                0.755891404214417, 0.770937350975443, 0.784785384817143, 0.797552007950479,
                0.809340543335114, 0.820242786104215, 0.830340439823572, 0.839706363236407,
                0.848405651677334, 0.856496575119626, 0.864031392358576, 0.871057058402467,
                0.877615839877453, 0.883745851211882, 0.889481522565262, 0.894854008899885,
                0.899891548241091, 0.904619776012425, 0.909062001340873, 0.913239450382379,
                0.917171480998301, 0.920875772501003, 0.92436849366537, 0.927664451759009,
                0.930777224965305, 0.933719280250451, 0.936502078449514, 0.939136168110381,
                0.941631269431952, 0.943996349459209, 0.946239689548337
            },
            LogNormalDefaultProbs,
            new[]
            {
                0, 0.097651733070336, 0.128253191451111, 0.152469057044131,
                0.173654763031272, 0.193040816698737, 0.211237202471418, 0.228597828182817,
                0.245349498538625, 0.261648040896079, 0.27760624185201, 0.293309146105391,
                0.308823058575631, 0.324201147878091, 0.339487096246912, 0.354717567913347,
                0.369923932170038, 0.385133499386258, 0.400370429028797, 0.415656411015843,
                0.431011186881839, 0.446452955509082, 0.461998694256657, 0.477664417166171,
                0.493465385775994, 0.509416283863278, 0.525531364495507, 0.541824575692156,
                0.558309669501743, 0.575000298211818, 0.591910100609554, 0.60905278061725,
                0.626442180183754, 0.644092347980331, 0.662017605199757, 0.680232609570648,
                0.698752418560753, 0.717592552642852, 0.736769059427467, 0.756298579422397,
                0.776198414156351, 0.796486597400003, 0.817181970230978, 0.83830426071875,
                0.859874169050893, 0.881913458984019, 0.904445056581968, 0.927493157301907,
                0.951083342608111, 0.975242707436093, 1, 1.02538577563835, 1.05143256663264,
                1.07817507021725, 1.1056503573353, 1.13389810509528, 1.16296085635852,
                1.19288431045622, 1.22371764971436, 1.25551390728272, 1.28833038275001,
                1.32222911322103, 1.35727740898496, 1.39354846467826, 1.43112205902591,
                1.47008535893506, 1.5105338470542, 1.55257239607904, 1.59631651832045,
                1.64189382566572, 1.689445743484, 1.73912953281917, 1.79112068915525,
                1.84561580419741, 1.90283600096821, 1.96303108415826, 2.02648459005379,
                2.09351997775484, 2.16450828201792, 2.23987765712004, 2.32012539450432,
                2.40583321584299, 2.49768696061235, 2.59650225595432, 2.70325846217579,
                2.81914427267467, 2.94562005759621, 3.08450480988435, 3.23810017494241,
                3.40937203383588, 3.60222447927916, 3.82192810072359, 4.07581839765843,
                4.37449475329341, 4.73401459733547, 5.18025160223302
            }),
        new TestData(new LogNormalDistribution(1, 2),
            DefaultX,
            new[]
            {
                0, 0.510234855730895, 0.425796571402452, 0.362293752685404,
                0.315115433092107, 0.278794046292731, 0.24992751374624, 0.22639327599457,
                0.206810537867381, 0.190243027548339, 0.17603266338215, 0.16370260975737,
                0.152898339656916, 0.143350401184004, 0.134850086629523, 0.127233055814411,
                0.120368024076892, 0.114148768481324, 0.108488363796208, 0.103314950974289,
                0.0985685803440131, 0.0941988222389077, 0.0901629346722469, 0.0864244413786881,
                0.0829520162739906, 0.0797185995553162, 0.0767006909072339, 0.0738777795371111,
                0.0712318809464259, 0.0687471577098465, 0.0664096069245068, 0.0642068009806542,
                0.0621276712865916, 0.0601623268311294, 0.058301901180254, 0.0565384228204008,
                0.0548647047789189, 0.0532742502461417, 0.0517611715466945, 0.0503201203001943,
                0.0489462270031511, 0.0476350485771772, 0.0463825226806316, 0.0451849277846394,
                0.0440388481800857, 0.0429411432174879, 0.0418889201926691, 0.0408795103826462,
                0.0399104478118654, 0.0389794503918358, 0.038084403129689
            },
            new[]
            {
                0, 0.0493394267528022, 0.0959942821100982, 0.135233791630521,
                0.168994731087331, 0.198616419757361, 0.225000664150064, 0.248778872427706,
                0.270410558314802, 0.290241187101901, 0.308537538725987, 0.32551026362922,
                0.341328827234735, 0.356131742801163, 0.370033779619676, 0.383131166616305,
                0.395505429859499, 0.407226276059249, 0.418353795318462, 0.428940168747573,
                0.439031009747689, 0.448666430078788, 0.457881896291462, 0.46670892446349,
                0.47517564878966, 0.4833072907274, 0.491126548995356, 0.498653926022123,
                0.505908002951862, 0.512905672691848, 0.519662338497517, 0.526192084066019,
                0.532507819930619, 0.538621410029273, 0.544543781598509, 0.550285020972083,
                0.55585445740811, 0.561260736702813, 0.566511886053806, 0.571615371396213,
                0.576578148239245, 0.581406706870264, 0.586107112660963, 0.5906850421005,
                0.595145815089131, 0.599494423949503, 0.603735559548713, 0.607873634870235,
                0.611912806329171, 0.615856993085543, 0.619709894577329
            },
            LogNormalDefaultProbs,
            new[]
            {
                0, 0.0259211575979212, 0.0447126946398988, 0.0631913903149937,
                0.0819724435467807, 0.101296111555059, 0.121292876725764, 0.142049163942128,
                0.163630716197325, 0.186092751165326, 0.209485002124057, 0.233854479378153,
                0.2592471087928, 0.285708774458231, 0.313286026941771, 0.342026595956804,
                0.37197978543294, 0.403196796964743, 0.435731009947904, 0.469638236560373,
                0.504976963718711, 0.54180859046675, 0.580197666972603, 0.620212139879725,
                0.661923607863611, 0.705407590700712, 0.750743814846126, 0.798016518371222,
                0.847314778087532, 0.898732861751843, 0.952370608392699, 1.00833384001128,
                1.06673480818541, 1.12769267944354, 1.19133406367815, 1.25779359033998,
                1.3272145377022, 1.39974952111691, 1.47556124691584, 1.5548233394477,
                1.63772124971251, 1.72445325516897, 1.81523156157937, 1.91028351924593,
                2.00985296771827, 2.11420172505561, 2.22361124005932, 2.3383844286122,
                2.45884771844336, 2.58535333037011, 2.71828182845905, 2.85804497672775,
                3.00508894613795, 3.15989792290738, 3.32299817783505, 3.49496266669459,
                3.67641624417891, 3.86804158884615, 4.07058595461049, 4.28486888628747,
                4.51179106348394, 4.75234446992247, 5.00762412565048, 5.27884166949715,
                5.56734114118676, 5.87461739007066, 6.20233763493467, 6.55236682264957,
                6.92679759039638, 7.3279858373572, 7.75859317141365, 8.22163783410303,
                8.72055614987436, 9.25927713127036, 9.84231365322021, 10.4748746630169,
                11.1630043273108, 11.9137559938178, 12.7354116011631, 13.6377610634878,
                14.6324617355151, 15.7335061835, 16.9578385064081, 18.3261775752072,
                19.864133451044, 21.6037471538144, 23.5856548441084, 25.8621952123871,
                28.5019807292673, 31.5968123363685, 35.2724826312618, 39.7063080246806,
                45.1569012875312, 52.017596541019, 60.9191264845408, 72.945110977082
            }),
    };

    [UsedImplicitly]
    public static TheoryData<string> TestDataKeys = TheoryDataHelper.Create(TestDataList.Select(it => it.Distribution.ToString()!));

    [Theory]
    [MemberData(nameof(TestDataKeys))]
    public void LogNormalDistributionTest(string testKey)
    {
        Check(TestDataList.First(it => it.Distribution.ToString() == testKey));
    }
}