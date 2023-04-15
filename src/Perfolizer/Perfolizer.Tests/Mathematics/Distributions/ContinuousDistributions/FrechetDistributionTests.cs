using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Perfolizer.Mathematics.Distributions.ContinuousDistributions;
using Perfolizer.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace Perfolizer.Tests.Mathematics.Distributions.ContinuousDistributions;

public class FrechetDistributionTests : DistributionTestsBase
{
    public FrechetDistributionTests(ITestOutputHelper output) : base(output)
    {
    }

    private static readonly List<TestData> TestDataList = new()
    {
        new TestData(new FrechetDistribution(),
            new[]
            {
                0, 0.05, 0.1, 0.15, 0.2, 0.25, 0.3, 0.35, 0.4, 0.45, 0.5, 0.55,
                0.6, 0.65, 0.7, 0.75, 0.8, 0.85, 0.9, 0.95, 1, 1.05, 1.1, 1.15,
                1.2, 1.25, 1.3, 1.35, 1.4, 1.45, 1.5, 1.55, 1.6, 1.65, 1.7, 1.75,
                1.8, 1.85, 1.9, 1.95, 2, 2.05, 2.1, 2.15, 2.2, 2.25, 2.3, 2.35,
                2.4, 2.45, 2.5, 2.55, 2.6, 2.65, 2.7, 2.75, 2.8, 2.85, 2.9, 2.95,
                3, 3.05, 3.1, 3.15, 3.2, 3.25, 3.3, 3.35, 3.4, 3.45, 3.5, 3.55,
                3.6, 3.65, 3.7, 3.75, 3.8, 3.85, 3.9, 3.95, 4, 4.05, 4.1, 4.15,
                4.2, 4.25, 4.3, 4.35, 4.4, 4.45, 4.5, 4.55, 4.6, 4.65, 4.7, 4.75,
                4.8, 4.85, 4.9, 4.95, 5
            },
            new[]
            {
                0, 8.24461448975422e-07, 0.00453999297624848, 0.0565615022817693,
                0.168448674977137, 0.293050222219747, 0.39637770385836, 0.468837708307081,
                0.513031241399367, 0.53515073195998, 0.541341132946451, 0.536597061758176,
                0.52465445232656, 0.508192123885674, 0.489083747840359, 0.468617134427959,
                0.447663745094047, 0.426803000548902, 0.406411096059143, 0.386723624300632,
                0.367879441171442, 0.349951298711224, 0.332967207875316, 0.31692532453635,
                0.301804311463249, 0.287570537035022, 0.274183058716672, 0.26159705276761,
                0.24976615283518, 0.238644021952388, 0.228185386236708, 0.218346691338189,
                0.209086495515231, 0.200365680007436, 0.19214753391071, 0.184397754124983,
                0.177084389116492, 0.17017774680444, 0.163650280859067, 0.157476465390796,
                0.151632664928158, 0.146097004378205, 0.140849242089672, 0.135870648019515,
                0.131143888210802, 0.126652916233077, 0.122382871849511, 0.118319986910714,
                0.114451498298688, 0.110765567630886, 0.107251207365702, 0.103898212913674,
                0.100697100343696, 0.0976390492737041, 0.0947158505455568, 0.0919198583006782,
                0.0892439460937666, 0.0866814667047875, 0.0842262153332178, 0.0818723958822459,
                0.0796145900637543, 0.0774477290770468, 0.075367067635194, 0.0733681601324447,
                0.0714468387643205, 0.0695991934287985, 0.0678215532524149, 0.066110469599253,
                0.0644627004336921, 0.0628751959195553, 0.0613450851490029, 0.0598696639042435,
                0.0584463833639635, 0.0570728396743856, 0.055746764312126, 0.0544660151725972,
                0.0532285683236659, 0.0520325103696736, 0.0508760313758209, 0.0497574183073483,
                0.0486750489419628, 0.0476273862176038, 0.046612972980942, 0.0456304271050011,
                0.0446784369470131, 0.0437557571200829, 0.0428612045544859, 0.041993654826454,
                0.0411520387341664, 0.0403353391023406, 0.0395425877983609, 0.0387728629442755,
                0.0380252863102719, 0.0372990208763993, 0.0365932685503709, 0.0359072680302461,
                0.0352402928016768, 0.0345916492602153, 0.0339606749499152, 0.0333467369101411,
                0.0327492301231193
            },
            new[]
            {
                0, 2.06115362243856e-09, 4.53999297624849e-05, 0.00127263380133981,
                0.00673794699908547, 0.0183156388887342, 0.0356739933472524,
                0.0574326192676174, 0.0820849986238988, 0.108368023221896, 0.135335283236613,
                0.162320611181848, 0.188875602837562, 0.214711172341697, 0.239651036441776,
                0.263597138115727, 0.28650479686019, 0.308365167896582, 0.329192987807906,
                0.34901807093132, 0.367879441171442, 0.385821306829124, 0.402890321529133,
                0.419133741699323, 0.434598208507078, 0.449328964117222, 0.463369369231175,
                0.47676062866897, 0.489541659556953, 0.501749056154897, 0.513417119032592,
                0.524577925939998, 0.53526142851899, 0.545495563820244, 0.555306373001951,
                0.564718122007759, 0.573753420737433, 0.582433338438195, 0.590777513901232,
                0.598804259648502, 0.606530659712633, 0.613972660899407, 0.621145157615452,
                0.628062070470208, 0.634736418940282, 0.641180388429955, 0.647405392083911,
                0.653422127714415, 0.659240630200444, 0.664870319704396, 0.670320046035639,
                0.675598129471162, 0.680712398323385, 0.685670223524587, 0.690478550477109,
                0.695143928398879, 0.69967253737513, 0.704070213309636, 0.708342470952361,
                0.712494525165244, 0.716531310573789, 0.720457499739228, 0.724277519974214,
                0.727995568914183, 0.731615628946642, 0.735141480591684, 0.738576714918798,
                0.741924745077617, 0.745188817013481, 0.748372019432507, 0.751477293075286,
                0.754507439353229, 0.757465128396966, 0.760352906562002, 0.763173203433005,
                0.765928338364649, 0.768620526593736, 0.771251884954487, 0.773824437226237,
                0.776340119140403, 0.778800783071405, 0.781208202434246, 0.783564075809635,
                0.785870030815882, 0.788127627745311, 0.790338362981498, 0.792503672212443,
                0.794624933453576, 0.796703469893462, 0.7987405525741, 0.800737402916808,
                0.802695195103864, 0.804615058325353, 0.806498078899943, 0.808345302277693,
                0.810157734932427, 0.811936346150635, 0.813682069723415, 0.815395805547463,
                0.817078421140731, 0.818730753077982
            },
            DefaultProbs,
            new[]
            {
                double.Epsilon, 0.217147240951626, 0.255622218635331, 0.285179948337453, 0.310667467279806,
                0.333808200695334, 0.355440460236682, 0.376044458274721, 0.395925350988716,
                0.415291772541269, 0.434294481903252, 0.453047327283263, 0.471639483925752,
                0.49014302080339, 0.508617802258229, 0.527114788714934, 0.545678333968646,
                0.564347830791268, 0.583158920382677, 0.602144402352639, 0.621334934559612,
                0.640759582751412, 0.660446261203587, 0.680422093286246, 0.700713712689139,
                0.721347520444482, 0.742349909011647, 0.763747461962093, 0.785567135862813,
                0.807836429563045, 0.830583545082537, 0.853837543572166, 0.877628499295106,
                0.9019876542077, 0.926947575467848, 0.952542318040335, 0.978807594485609,
                1.00578095399953, 1.03350197280905, 1.06201245811803, 1.09135666793729,
                1.12158154932325, 1.15273699779339, 1.18487614098806, 1.21805565001367,
                1.25233608234037, 1.28778226064894, 1.32446369264069, 1.36245503755758,
                1.40183662602856, 1.44269504088896, 1.48512376784353, 1.52922392630136,
                1.57510509245039, 1.62288622872153, 1.67269673629447, 1.72467765031151,
                1.77898300111446, 1.83578136925, 1.8952576673945, 1.95761518897122,
                2.02307797138477, 2.09189353188055, 2.16433604657353, 2.24071005886228,
                2.32135482314573, 2.40664941467797, 2.49701876810989, 2.5929408479004,
                2.69495520621089, 2.80367325205713, 2.91979064480742, 3.04410234313819,
                3.17752099792257, 3.3210995893637, 3.47605949678221, 3.64382558560206,
                3.82607044722275, 4.024770704078, 4.24227940162749, 4.48142011772455,
                4.74561079051495, 5.03902882208881, 5.36683445379931, 5.73547790711763,
                6.15312938062203, 6.63029333120316, 7.1807062694623, 7.82268345259652,
                8.58120013682234, 9.4912215810299, 10.6032530526401, 11.993052337608,
                13.7796672587364, 16.161510712013, 19.4957257462237, 24.4965982616019,
                32.8307951052906, 49.4983164525091, 99.4991624734221, double.PositiveInfinity
            }),
        new TestData(new FrechetDistribution(-1, 2, 3),
            new[]
            {
                -1, -0.95, -0.9, -0.85, -0.8, -0.75, -0.7, -0.65, -0.6, -0.55,
                -0.5, -0.45, -0.4, -0.35, -0.3, -0.25, -0.2, -0.15, -0.1, -0.0499999999999999,
                0, 0.05, 0.1, 0.15, 0.2, 0.25, 0.3, 0.35, 0.4, 0.45, 0.5, 0.55,
                0.6, 0.65, 0.7, 0.75, 0.8, 0.85, 0.9, 0.95, 1, 1.05, 1.1, 1.15,
                1.2, 1.25, 1.3, 1.35, 1.4, 1.45, 1.5, 1.55, 1.6, 1.65, 1.7, 1.75,
                1.8, 1.85, 1.9, 1.95, 2, 2.05, 2.1, 2.15, 2.2, 2.25, 2.3, 2.35,
                2.4, 2.45, 2.5, 2.55, 2.6, 2.65, 2.7, 2.75, 2.8, 2.85, 2.9, 2.95,
                3, 3.05, 3.1, 3.15, 3.2, 3.25, 3.3, 3.35, 3.4, 3.45, 3.5, 3.55,
                3.6, 3.65, 3.7, 3.75, 3.8, 3.85, 3.9, 3.95, 4
            },
            new[]
            {
                0, 0, 0, 0, 0, 2.68953049316544e-219, 6.19269560078033e-126,
                1.47706690301343e-78, 4.84351934328553e-52, 4.36515092165677e-36,
                6.15863381970675e-26, 3.43621763775268e-19, 1.52273885283632e-14,
                3.00112985687621e-11, 7.42167136156907e-09, 4.41017692697929e-07,
                9.59400662455556e-06, 0.000101187593303734, 0.0006270771322947,
                0.00261215629497434, 0.00805110306966028, 0.0196867862980385,
                0.0402073567615389, 0.0712811189059812, 0.112944127838169, 0.163568997450288,
                0.2203072066895, 0.279738120142035, 0.338481103916982, 0.393633806809826,
                0.443003781677631, 0.485165254345631, 0.519397555251499, 0.545560449947324,
                0.56394859909252, 0.575152134376398, 0.579937498912823, 0.579153668754719,
                0.573663383639088, 0.564296203705114, 0.551819161757164, 0.536920761454917,
                0.520204566786423, 0.502189315576998, 0.483313188528527, 0.463940486837282,
                0.44436948294095, 0.424840607973427, 0.405544438201512, 0.386629158541612,
                0.368207332052299, 0.350361905986627, 0.333151450728915, 0.316614668094245,
                0.300774227901651, 0.285640002249028, 0.271211769700438, 0.257481459588222,
                0.244435001859429, 0.232053841717983, 0.220316171616565, 0.209197926489623,
                0.198673581818746, 0.188716788359066, 0.179300872206303, 0.170399224361559,
                0.161985600030449, 0.154034344529003, 0.146520559805468, 0.139420223166212,
                0.132710267758176, 0.126368632656291, 0.12037428898347, 0.114707247310151,
                0.10934855060221, 0.104280256177879, 0.0994854094681572, 0.0949480118275382,
                0.090652984192487, 0.0865861280173824, 0.0827340846173058, 0.0790842938024684,
                0.0756249524903525, 0.0723449738207124, 0.0692339471686467, 0.0662820993464764,
                0.0634802572014916, 0.0608198117499884, 0.0582926839352504, 0.055891292055668,
                0.0536085208769008, 0.0514376924171387, 0.0493725383756734, 0.0474071741609832,
                0.0455360744643968, 0.0437540503183696, 0.0420562275738155, 0.040438026728293,
                0.0388951440357059, 0.0374235338282146, 0.03601939198198
            },
            new[]
            {
                0, 0, 0, 0, 0, 4.37749103705305e-223, 2.09003476526341e-129,
                9.23551467222727e-82, 5.16642063283793e-55, 7.45826958254945e-39,
                1.60381089054864e-28, 1.31014745922753e-21, 8.22278980531616e-17,
                2.23216848547504e-13, 7.42476372463639e-11, 5.81419809709184e-09,
                1.63737713059082e-07, 2.20085650529197e-06, 1.71427211041064e-05,
                8.86507345097267e-05, 0.000335462627902512, 0.000997058824486674,
                0.00245281629310705, 0.00519463010306476, 0.00975837264521783,
                0.0166390988617236, 0.0262174755427451, 0.0387146631006259, 0.0541795420336449,
                0.0725025293005886, 0.0934461101976254, 0.116682370015243, 0.141830159087343,
                0.168487394365099, 0.196256462270027, 0.224762414491818, 0.253664662024469,
                0.282663338277868, 0.311501607580124, 0.339965097342646, 0.367879441171442,
                0.395106705158752, 0.421541268138293, 0.447105555803114, 0.471745892883077,
                0.495428635113836, 0.51813666864866, 0.539866313217807, 0.560624631369771,
                0.580427124945272, 0.599295787845538, 0.617257478318395, 0.634342572284569,
                0.650583860135144, 0.666015651876171, 0.680673058744795, 0.694591422987468,
                0.707805871066336, 0.720350968958912, 0.732260461336891, 0.743567079205906,
                0.754302403048179, 0.764496770645124, 0.774179220590005, 0.783377464060818,
                0.792117878741941, 0.800425519890459, 0.808324144468655, 0.815836245034169,
                0.822983090717588, 0.829784773144222, 0.836260255590587, 0.842427424021917,
                0.848303138947985, 0.853903287271623, 0.859242833496926, 0.864335869819981,
                0.869195664750504, 0.873834710013548, 0.878264765560785, 0.882496902584595,
                0.886541544478355, 0.89040850572538, 0.894107028729158, 0.897645818620372,
                0.901033076093271, 0.90427652833632, 0.907383458130685, 0.910360731195735,
                0.913214821864091, 0.915951837170173, 0.91857753943627, 0.921097367439122,
                0.923516456238114, 0.92583965574376, 0.928071548102253, 0.93021646396868,
                0.932278497738167, 0.934261521800757, 0.936169199882369, 0.938004999530729
            },
            DefaultProbs,
            new[]
            {
                double.Epsilon, 0.202120770018241, 0.269295856400356, 0.316445823423417, 0.354550667448558,
                0.387380745522488, 0.416725191960477, 0.443587324203754, 0.468591800570624,
                0.492156716427974, 0.514577262661815, 0.536070633962521, 0.556801999889682,
                0.576900424247291, 0.596469091010285, 0.615592131399697, 0.634339331842162,
                0.65276947153036, 0.670932745703448, 0.688872562316617, 0.706626899067589,
                0.724229345542934, 0.741709915701339, 0.759095690122497, 0.776411330247635,
                0.793679495126575, 0.810921183066413, 0.828156014852927, 0.845402471119865,
                0.862678093469989, 0.87999965676962, 0.897383318417871, 0.914844749176276,
                0.932399249224843, 0.950061852409562, 0.967847421108952, 0.98577073373352,
                1.00384656655306, 1.02208977130125, 1.04051534981934, 1.05913852685906,
                1.07797482206106, 1.09704012205217, 1.1163507535588, 1.13592355841085,
                1.15577597130907, 1.17592610124756, 1.19639281752131, 1.21719584130704,
                1.23835584388536, 1.25989455267478, 1.28183486637593, 1.30420098068204,
                1.3270185262021, 1.35031472047357, 1.37411853621833, 1.39846088832824,
                1.42337484246636, 1.44889584865152, 1.47506200377434, 1.50191434769605,
                1.52949719843469, 1.55785853298437, 1.58705042158734, 1.61712952484688,
                1.64815766500739, 1.68020248513838, 1.71333821297258, 1.74764654993891,
                1.78321771073047, 1.82015164486637, 1.8585594795629, 1.89856523339789,
                1.94030786352107, 1.98394372663146, 2.02964955715874, 2.07762609725385,
                2.12810255549671, 2.18134212932302, 2.23764890696827, 2.29737657865596,
                2.36093954982554, 2.42882728644606, 2.50162307388424, 2.58002890171889,
                2.66489900675012, 2.75728590372587, 2.85850484290432, 2.97022617176093,
                3.09461122491833, 3.23451848624939, 3.39382785463595, 3.57797312316245,
                3.79486340084558, 4.05658502066763, 4.38281926340028, 4.80851687799798,
                5.40408561428255, 6.34333720860043, 8.26765384279065, double.PositiveInfinity
            }),
    };

    [UsedImplicitly]
    public static TheoryData<string> TestDataKeys = TheoryDataHelper.Create(TestDataList.Select(it => it.Distribution.ToString()!));

    [Theory]
    [MemberData(nameof(TestDataKeys))]
    public void FrechetDistributionTest(string testKey)
    {
        Check(TestDataList.First(it => it.Distribution.ToString() == testKey));
    }

    [Fact]
    public void FrechetDistributionTest1()
    {
        var frechet = new FrechetDistribution();
        AssertEqual("Location", 0, frechet.Location);
        AssertEqual("Scale", 1, frechet.Scale);
        AssertEqual("Mean", double.PositiveInfinity, frechet.Mean);
        AssertEqual("Median", 1.4426950408889634, frechet.Median);
        AssertEqual("Variance", double.PositiveInfinity, frechet.Variance);
    }

    [Fact]
    public void FrechetDistributionTest2()
    {
        var frechet = new FrechetDistribution(-1, 2, 3);
        AssertEqual("Location", -1, frechet.Location);
        AssertEqual("Scale", 2, frechet.Scale);
        AssertEqual("Shape", 3, frechet.Shape);
        AssertEqual("Mean", 1.7082358814691916, frechet.Mean);
        AssertEqual("Median", 1.2598945526747802, frechet.Median);
        AssertEqual("Variance", 3.3812125776279194, frechet.Variance);
    }
}