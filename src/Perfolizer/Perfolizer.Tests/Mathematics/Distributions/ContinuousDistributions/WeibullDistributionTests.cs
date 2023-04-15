using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Perfolizer.Mathematics.Distributions.ContinuousDistributions;
using Perfolizer.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace Perfolizer.Tests.Mathematics.Distributions.ContinuousDistributions;

public class WeibullDistributionTests : DistributionTestsBase
{
    public WeibullDistributionTests(ITestOutputHelper output) : base(output)
    {
    }

    private static readonly List<TestData> TestDataList = new()
    {
        new TestData(new WeibullDistribution(1),
            new[]
            {
                0.5, 0.55, 0.6, 0.65, 0.7, 0.75, 0.8, 0.85, 0.9, 0.95, 1, 1.05,
                1.1, 1.15, 1.2, 1.25, 1.3, 1.35, 1.4, 1.45, 1.5, 1.55, 1.6, 1.65,
                1.7, 1.75, 1.8, 1.85, 1.9, 1.95, 2, 2.05, 2.1, 2.15, 2.2, 2.25,
                2.3, 2.35, 2.4, 2.45, 2.5, 2.55, 2.6, 2.65, 2.7, 2.75, 2.8, 2.85,
                2.9, 2.95, 3, 3.05, 3.1, 3.15, 3.2, 3.25, 3.3, 3.35, 3.4, 3.45,
                3.5, 3.55, 3.6, 3.65, 3.7, 3.75, 3.8, 3.85, 3.9, 3.95, 4, 4.05,
                4.1, 4.15, 4.2, 4.25, 4.3, 4.35, 4.4, 4.45, 4.5, 4.55, 4.6, 4.65,
                4.7, 4.75, 4.8, 4.85, 4.9, 4.95, 5, 5.05, 5.1, 5.15, 5.2, 5.25,
                5.3, 5.35, 5.4, 5.45, 5.5
            },
            new[]
            {
                0.606530659712633, 0.576949810380487, 0.548811636094026, 0.522045776761016,
                0.49658530379141, 0.472366552741015, 0.449328964117222, 0.427414931948727,
                0.406569659740599, 0.386741023454501, 0.367879441171442, 0.349937749111155,
                0.33287108369808, 0.316636769379053, 0.301194211912202, 0.28650479686019,
                0.272531793034013, 0.259240260645892, 0.246596963941606, 0.234570288093798,
                0.22313016014843, 0.212247973826743, 0.201896517994655, 0.192049908620754,
                0.182683524052735, 0.173773943450445, 0.165298888221587, 0.157237166313628,
                0.149568619222635, 0.142274071586514, 0.135335283236613, 0.128734903587804,
                0.122456428252982, 0.116484157773497, 0.110803158362334, 0.105399224561864,
                0.100258843722804, 0.0953691622155496, 0.0907179532894125, 0.0862935864993705,
                0.0820849986238988, 0.0780816660011531, 0.0742735782143339, 0.0706512130604296,
                0.0672055127397498, 0.0639278612067076, 0.060810062625218, 0.0578443208748385,
                0.0550232200564072, 0.0523397059484324, 0.0497870683678639, 0.0473589243911409,
                0.0450492023935578, 0.0428521268670402, 0.0407622039783662, 0.038774207831722,
                0.03688316740124, 0.035084354100845, 0.0333732699603261, 0.0317456363780679,
                0.0301973834223185, 0.0287246396542394, 0.0273237224472926, 0.0259911287787553,
                0.0247235264703394, 0.0235177458560091, 0.0223707718561656, 0.0212797364383772,
                0.0202419114458044, 0.0192547017753869, 0.0183156388887342, 0.0174223746394935,
                0.0165726754017613, 0.0157644164848545, 0.0149955768204777, 0.0142642339089993,
                0.0135685590122009, 0.0129068125804799, 0.0122773399030684, 0.0116785669703954,
                0.0111089965382423, 0.0105672043838527, 0.0100518357446336, 0.0095616019305435,
                0.00909527710169582, 0.00865169520312063, 0.00822974704902003,
                0.00782837754922577, 0.00744658307092434, 0.00708340892905212,
                0.00673794699908547, 0.00640933344625638, 0.00609674656551563,
                0.00579940472684214, 0.00551656442076077, 0.00524751839918138,
                0.00499159390691021, 0.00474815099941147, 0.00451658094261267,
                0.00429630469075234, 0.00408677143846407
            },
            new[]
            {
                0.393469340287367, 0.423050189619513, 0.451188363905974, 0.477954223238984,
                0.50341469620859, 0.527633447258985, 0.550671035882778, 0.572585068051273,
                0.593430340259401, 0.613258976545499, 0.632120558828558, 0.650062250888845,
                0.667128916301921, 0.683363230620947, 0.698805788087798, 0.71349520313981,
                0.727468206965987, 0.740759739354109, 0.753403036058394, 0.765429711906202,
                0.77686983985157, 0.787752026173257, 0.798103482005345, 0.807950091379246,
                0.817316475947265, 0.826226056549555, 0.834701111778413, 0.842762833686372,
                0.850431380777365, 0.857725928413486, 0.864664716763387, 0.871265096412196,
                0.877543571747018, 0.883515842226503, 0.889196841637666, 0.894600775438136,
                0.899741156277196, 0.90463083778445, 0.909282046710588, 0.91370641350063,
                0.917915001376101, 0.921918333998847, 0.925726421785666, 0.92934878693957,
                0.93279448726025, 0.936072138793292, 0.939189937374782, 0.942155679125162,
                0.944976779943593, 0.947660294051568, 0.950212931632136, 0.952641075608859,
                0.954950797606442, 0.95714787313296, 0.959237796021634, 0.961225792168278,
                0.96311683259876, 0.964915645899155, 0.966626730039674, 0.968254363621932,
                0.969802616577682, 0.971275360345761, 0.972676277552707, 0.974008871221245,
                0.975276473529661, 0.976482254143991, 0.977629228143834, 0.978720263561623,
                0.979758088554196, 0.980745298224613, 0.981684361111266, 0.982577625360507,
                0.983427324598239, 0.984235583515146, 0.985004423179522, 0.985735766091001,
                0.986431440987799, 0.98709318741952, 0.987722660096932, 0.988321433029605,
                0.988891003461758, 0.989432795616147, 0.989948164255366, 0.990438398069457,
                0.990904722898304, 0.991348304796879, 0.99177025295098, 0.992171622450774,
                0.992553416929076, 0.992916591070948, 0.993262053000915, 0.993590666553744,
                0.993903253434484, 0.994200595273158, 0.994483435579239, 0.994752481600819,
                0.99500840609309, 0.995251849000588, 0.995483419057387, 0.995703695309248,
                0.995913228561536
            },
            DefaultProbs,
            new[]
            {
                0, 0.0100503358535014, 0.0202027073175194, 0.0304592074847085,
                0.0408219945202551, 0.0512932943875505, 0.0618754037180875, 0.0725706928348354,
                0.0833816089390511, 0.0943106794712413, 0.105360515657826, 0.116533816255952,
                0.127833371509885, 0.139262067333508, 0.150822889734584, 0.162518929497775,
                0.174353387144778, 0.186329578191493, 0.198450938723838, 0.210721031315653,
                0.22314355131421, 0.23572233352107, 0.2484613592985, 0.261364764134408,
                0.27443684570176, 0.287682072451781, 0.301105092783922, 0.3147107448397,
                0.328504066972036, 0.342490308946776, 0.356674943938732, 0.371063681390832,
                0.385662480811985, 0.400477566597125, 0.415515443961666, 0.430782916092454,
                0.446287102628419, 0.462035459596559, 0.478035800943, 0.49429632181478,
                0.510825623765991, 0.527632742082372, 0.544727175441672, 0.562118918153541,
                0.579818495252942, 0.597837000755621, 0.616186139423817, 0.63487827243597,
                0.653926467406664, 0.673344553263766, 0.693147180559945, 0.713349887877465,
                0.7339691750802, 0.755022584278033, 0.776528789498996, 0.798507696217772,
                0.82098055206983, 0.843970070294529, 0.867500567704723, 0.891598119283784,
                0.916290731874155, 0.941608539858445, 0.967584026261706, 0.994252273343867,
                1.02165124753198, 1.04982212449868, 1.07880966137193, 1.10866262452161,
                1.13943428318837, 1.17118298150295, 1.20397280432594, 1.23787435600162,
                1.27296567581289, 1.30933331998376, 1.34707364796661, 1.38629436111989,
                1.42711635564015, 1.46967597005894, 1.51412773262978, 1.56064774826467,
                1.6094379124341, 1.66073120682165, 1.71479842809193, 1.77195684193188,
                1.83258146374831, 1.89711998488588, 1.96611285637283, 2.04022082852655,
                2.12026353620009, 2.20727491318972, 2.30258509299405, 2.40794560865187,
                2.52572864430826, 2.65926003693278, 2.81341071676004, 2.99573227355399,
                3.2188758248682, 3.50655789731998, 3.91202300542815, 4.60517018598809,
                double.PositiveInfinity
            }),
        new TestData(new WeibullDistribution(2),
            new[]
            {
                0.5, 0.55, 0.6, 0.65, 0.7, 0.75, 0.8, 0.85, 0.9, 0.95, 1, 1.05,
                1.1, 1.15, 1.2, 1.25, 1.3, 1.35, 1.4, 1.45, 1.5, 1.55, 1.6, 1.65,
                1.7, 1.75, 1.8, 1.85, 1.9, 1.95, 2, 2.05, 2.1, 2.15, 2.2, 2.25,
                2.3, 2.35, 2.4, 2.45, 2.5, 2.55, 2.6, 2.65, 2.7, 2.75, 2.8, 2.85,
                2.9, 2.95, 3, 3.05, 3.1, 3.15, 3.2, 3.25, 3.3, 3.35, 3.4, 3.45,
                3.5, 3.55, 3.6, 3.65, 3.7, 3.75, 3.8, 3.85, 3.9, 3.95, 4, 4.05,
                4.1, 4.15, 4.2, 4.25, 4.3, 4.35, 4.4, 4.45, 4.5, 4.55, 4.6, 4.65,
                4.7, 4.75, 4.8, 4.85, 4.9, 4.95, 5, 5.05, 5.1, 5.15, 5.2, 5.25,
                5.3, 5.35, 5.4, 5.45, 5.5
            },
            new[]
            {
                0.778800783071405, 0.812865337084839, 0.837211591285237, 0.852028130624893,
                0.857676951858182, 0.854674237096384, 0.843667878468878, 0.825412721761935,
                0.800744519201294, 0.770553559620309, 0.735758882342885, 0.697283885223787,
                0.656034014745752, 0.612877084971105, 0.568626620837092, 0.524028467877744,
                0.479750762381772, 0.436377219656416, 0.394403578578926, 0.354236941665971,
                0.316197673685593, 0.280523469157457, 0.247375169418559, 0.216843901650759,
                0.188959122879042, 0.163697178343856, 0.140990022356353, 0.120733797173715,
                0.102797018092132, 0.0870281676301689, 0.0732625555549367, 0.0613283522723677,
                0.0510517489856427, 0.0422612377921326, 0.0347910378270111, 0.0284837194236859,
                0.0231920971945785, 0.0187804754013978, 0.0151253356725333, 0.0121155588757835,
                0.00965227068113855, 0.00764839497558221, 0.00602799170430387,
                0.00472544671597466, 0.00368457148488443, 0.00285766075185161,
                0.00220454662766843, 0.0016916788764213, 0.00129125317012955,
                0.000980402212982936, 0.000740458824520077, 0.000556295333809822,
                0.000415739910677428, 0.000309067651974108, 0.000228562237706465,
                0.000168142651447252, 0.000123048699388011, 8.95787462096535e-05,
                6.48731075369387e-05, 4.67368049841558e-05, 3.34958217449031e-05,
                2.3881529646262e-05, 1.69385414400703e-05, 1.19518359925322e-05,
                8.38958082673493e-06, 5.85861705622837e-06, 4.07006433012276e-06,
                2.81294193272978e-06, 1.93408489407512e-06, 1.32296220547862e-06,
                9.00281397754073e-07, 6.09494483869227e-07, 4.10509877702898e-07,
                2.75068828484602e-07, 1.8336845479054e-07, 1.21611556307825e-07,
                8.02404731407425e-08, 5.26722558576187e-08, 3.43986582215307e-08,
                2.23497942161145e-08, 1.44470524966705e-08, 9.29094481914997e-09,
                5.9445172312576e-09, 3.78399464910988e-09, 2.39641896756844e-09,
                1.50992145897906e-09, 9.46512535295185e-10, 5.90309515235276e-10,
                3.66281990138536e-10, 2.26117748141377e-10, 1.3887943864964e-10,
                8.48645571044917e-11, 5.15941779770064e-11, 3.12077047412535e-11,
                1.87806469501374e-11, 1.12446940016335e-11, 6.69844303828584e-12,
                3.96999508791134e-12, 2.34097439322847e-12, 1.37339242978404e-12,
                8.01649650540166e-13
            },
            new[]
            {
                0.221199216928595, 0.261031511741056, 0.302323673928969, 0.34459374567316,
                0.387373605815584, 0.430217175269077, 0.472707575956952, 0.514463104845921,
                0.555141933777059, 0.594445494936679, 0.632120558828558, 0.667960054655339,
                0.701802720570113, 0.733531702186476, 0.763072241317878, 0.790388612848902,
                0.815480476007011, 0.838378807534661, 0.859141579078955, 0.87784933046001,
                0.894600775438136, 0.909508558336304, 0.9226952595567, 0.934289726772497,
                0.944423787388517, 0.953229377616041, 0.960836104901013, 0.967369244007104,
                0.97294815313365, 0.977685085223034, 0.981684361111266, 0.985041865299423,
                0.987844821670085, 0.99017180516462, 0.992092945948407, 0.993670284572514,
                0.994958239740309, 0.996004154169915, 0.996848888401556, 0.997527436964126,
                0.998069545863772, 0.99850031471067, 0.998840770826095, 0.999108406280005,
                0.999317671947244, 0.999480425317845, 0.999606330959345, 0.999703214232207,
                0.999777370143081, 0.999833830133393, 0.999876590195913, 0.999908804043638,
                0.999932945175697, 0.999950941642544, 0.999964287150358, 0.999974131899777,
                0.999981356257668, 0.999986630037879, 0.999990459837127, 0.999993226550002,
                0.999995214882608, 0.999996636404275, 0.9999976474248, 0.999998362762193,
                0.999998866272861, 0.999999218851059, 0.99999946446522, 0.999999634682866,
                0.999999752040398, 0.99999983253643, 0.999999887464825, 0.999999924753767,
                0.99999994993782, 0.999999966859177, 0.999999978170422, 0.999999985692758,
                0.999999990669712, 0.999999993945718, 0.999999996091062, 0.999999997488787,
                0.999999998394772, 0.999999998979017, 0.999999999353857, 0.999999999593119,
                0.999999999745062, 0.999999999841061, 0.999999999901405, 0.999999999939143,
                0.999999999962624, 0.99999999997716, 0.999999999986112, 0.999999999991598,
                0.999999999994942, 0.99999999999697, 0.999999999998194, 0.999999999998929,
                0.999999999999368, 0.999999999999629, 0.999999999999783, 0.999999999999874,
                0.999999999999927
            },
            DefaultProbs,
            new[]
            {
                0, 0.100251363349839, 0.142136228026212, 0.174525664258036,
                0.202044535982182, 0.226480229573247, 0.24874767077922, 0.26938948167075,
                0.288758738290378, 0.307100438735019, 0.324592845974501, 0.341370497049689,
                0.357537930169492, 0.373178331811358, 0.388359227693361, 0.403136365883524,
                0.417556447854392, 0.43165909951198, 0.445478325762139, 0.459043605026421,
                0.472380727077439, 0.485512444249444, 0.498458984569944, 0.511238461125929,
                0.523867202353574, 0.536360021302652, 0.548730437267627, 0.560990859853973,
                0.57315274314273, 0.585226715851879, 0.597222692082888, 0.609149966256941,
                0.621017295098924, 0.632832968955573, 0.644604874292512, 0.656340548871129,
                0.668047230836577, 0.6797319027356, 0.691401331314165, 0.703062103810737,
                0.714720661353784, 0.726383329986566, 0.738056349773967, 0.749745902391964,
                0.761458137557766, 0.773199198625827, 0.784975247650406, 0.796792490198025,
                0.808657200182292, 0.820575744988703, 0.832554611157698, 0.844600430900591,
                0.856720009734919, 0.86892035554361, 0.881208709386713, 0.893592578425857,
                0.906079771361126, 0.918678436828975, 0.931397105269671, 0.944244734845677,
                0.957230762080991, 0.970365157999011, 0.983658490667216, 0.997121995216166,
                1.01076765259479, 1.02460827856244, 1.03865762471179, 1.05293049368019,
                1.06744287115909, 1.08221207787704, 1.09725694544438, 1.11259802085102,
                1.12825780556258, 1.14426103664494, 1.16063501927463, 1.17741002251547,
                1.19461975357858, 1.21230193023807, 1.23049897709416, 1.24925887960209,
                1.26863624117952, 1.28869360471046, 1.30950312259724, 1.33114869264552,
                1.35372872605567, 1.37735978774098, 1.40218146342506, 1.42836298906355,
                1.45611247374648, 1.48569004613672, 1.51742712938515, 1.55175565365552,
                1.58925411571223, 1.63072377701828, 1.67732248442571, 1.73081838260229,
                1.7941225779941, 1.8725805449486, 1.97788346608898, 2.14596602628935,
                double.PositiveInfinity
            }),
        new TestData(new WeibullDistribution(2, 3),
            new[]
            {
                0.5, 0.55, 0.6, 0.65, 0.7, 0.75, 0.8, 0.85, 0.9, 0.95, 1, 1.05,
                1.1, 1.15, 1.2, 1.25, 1.3, 1.35, 1.4, 1.45, 1.5, 1.55, 1.6, 1.65,
                1.7, 1.75, 1.8, 1.85, 1.9, 1.95, 2, 2.05, 2.1, 2.15, 2.2, 2.25,
                2.3, 2.35, 2.4, 2.45, 2.5, 2.55, 2.6, 2.65, 2.7, 2.75, 2.8, 2.85,
                2.9, 2.95, 3, 3.05, 3.1, 3.15, 3.2, 3.25, 3.3, 3.35, 3.4, 3.45,
                3.5, 3.55, 3.6, 3.65, 3.7, 3.75, 3.8, 3.85, 3.9, 3.95, 4, 4.05,
                4.1, 4.15, 4.2, 4.25, 4.3, 4.35, 4.4, 4.45, 4.5, 4.55, 4.6, 4.65,
                4.7, 4.75, 4.8, 4.85, 4.9, 4.95, 5, 5.05, 5.1, 5.15, 5.2, 5.25,
                5.3, 5.35, 5.4, 5.45, 5.5
            },
            new[]
            {
                0.108067164124039, 0.118182468146718, 0.128105258553643, 0.137820280565959,
                0.147312840752818, 0.156568843802246, 0.165574827042018, 0.174317992593679,
                0.182786237054246, 0.190968178611918, 0.198853181514304, 0.206431377820146,
                0.213693686378193, 0.220631828989751, 0.227238343724323, 0.233506595370696,
                0.239430783018679, 0.245005944779433, 0.250227959664845, 0.25509354665863,
                0.259600261023802, 0.263746487902615, 0.267531433276197, 0.270955112361613,
                0.274018335534127, 0.27672269187181, 0.279070530428412, 0.28106493934848,
                0.282709722946059, 0.284009376874964, 0.284969061524424, 0.285594573779013,
                0.285892317286061, 0.285869271377221, 0.285532958793565, 0.284891412365462,
                0.283953140799607, 0.282727093725882, 0.281222626156293, 0.279449462507043,
                0.277417660332931, 0.275137573920645, 0.27261981788431, 0.269875230902786,
                0.266914839733765, 0.26374982363473, 0.260391479315373, 0.256851186540103,
                0.253140374492946, 0.249270489010426, 0.245252960780962, 0.24109917460206,
                0.236820439779026, 0.232427961741262, 0.227932814944385, 0.223345917118526,
                0.218678004915251, 0.213939610997618, 0.209141042610065, 0.204292361657035,
                0.199403366311654, 0.194483574168302, 0.189542206945697, 0.184588176740103,
                0.179630073821512, 0.174676155959248, 0.169734339257285, 0.16481219047378,
                0.159916920793924, 0.155055381020101, 0.150234058138725, 0.145459073218805,
                0.140736180593403, 0.136070768271703, 0.131467859526309, 0.126932115597722,
                0.122467839455703, 0.118078980555324, 0.113769140524066, 0.109541579715188,
                0.105399224561864, 0.101344675666219, 0.0973802165573171, 0.0935078230524857,
                0.0897291731568863, 0.0860456574371723, 0.0824583898061864, 0.0789682186570529,
                0.0755757382866474, 0.0722813005502531, 0.0690850266912403, 0.065986819291789,
                0.0629863742930141, 0.0600831930353156, 0.0572765942723425, 0.0545657261146188,
                0.0519495778616045, 0.0494269916837338, 0.0469966741187845, 0.0446572073497479,
                0.0424070602341913
            },
            new[]
            {
                0.0273955228836516, 0.0330525333450358, 0.0392105608476768,
                0.0458595960818228, 0.0529888808747445, 0.0605869371865242, 0.068641597888648,
                0.0771400392099347, 0.0860688147287718, 0.0954138907856537, 0.10516068318563,
                0.115294095056516, 0.125798555725575, 0.136658060474889, 0.147856211033789,
                0.159376256665495, 0.171201135704574, 0.183313517401889, 0.195695843934428,
                0.208330372438734, 0.221199216928595, 0.234284389960151, 0.247567843910697,
                0.261031511741056, 0.274657347115547, 0.288427363758203, 0.302323673928969,
                0.316328525909104, 0.330424340390914, 0.34459374567316, 0.358819611570045,
                0.373085081948508, 0.387373605815584, 0.401668966884886, 0.415955311558617,
                0.430217175269077, 0.444439507131205, 0.458607692865332, 0.472707575956952,
                0.486725477027881, 0.500648211400724, 0.514463104845921, 0.528158007507926,
                0.541721306014137, 0.555141933777059, 0.568409379506805, 0.581513693957436,
                0.59444549493668, 0.607195970614394, 0.619756881170537, 0.632120558828558,
                0.64427990632483, 0.656228393869156, 0.667960054655339, 0.679469478984459,
                0.690751807066656, 0.701802720570113, 0.712618432988274, 0.723195678898444,
                0.733531702186476, 0.743624243313588, 0.753471525702153, 0.763072241317878,
                0.7724255355259, 0.781530991298161, 0.790388612848902, 0.798998808774268,
                0.807362374770906, 0.815480476007011, 0.823354629217607, 0.830986684593934,
                0.838378807534661, 0.845533460324314, 0.852453383801768, 0.859141579078955,
                0.865601289367118, 0.871835981964962, 0.87784933046001, 0.883645197191296,
                0.889227616018349, 0.894600775438136, 0.899769002088355, 0.90473674467219,
                0.909508558336304, 0.914089089530641, 0.91848306137531, 0.9226952595567,
                0.926730518771807, 0.930593709736752, 0.934289726772497, 0.937823475977884,
                0.941199863997416, 0.944423787388517, 0.947500122590501, 0.950433716495088,
                0.953229377616041, 0.955891867853355, 0.958425894845457, 0.960836104901013,
                0.963127076500208, 0.965303314353843
            },
            DefaultProbs,
            new[]
            {
                0, 0.300754090049517, 0.426408684078637, 0.523576992774107,
                0.606133607946545, 0.67944068871974, 0.746243012337662, 0.80816844501225,
                0.866276214871134, 0.921301316205058, 0.973778537923504, 1.02411149114907,
                1.07261379050848, 1.11953499543407, 1.16507768308008, 1.20940909765057,
                1.25266934356318, 1.29497729853594, 1.33643497728642, 1.37713081507926,
                1.41714218123232, 1.45653733274833, 1.49537695370983, 1.53371538337779,
                1.57160160706072, 1.60908006390795, 1.64619131180288, 1.68297257956192,
                1.71945822942819, 1.75568014755564, 1.79166807624866, 1.82744989877082,
                1.86305188529677, 1.89849890686672, 1.93381462287754, 1.96902164661339,
                2.00414169250973, 2.0391957082068, 2.0742039939425, 2.10918631143221,
                2.14416198406135, 2.1791499899597, 2.2141690493219, 2.24923770717589,
                2.2843744126733, 2.31959759587748, 2.35492574295122, 2.39037747059407,
                2.42597160054688, 2.46172723496611, 2.49766383347309, 2.53380129270177,
                2.57016002920476, 2.60676106663083, 2.64362612816014, 2.68077773527757,
                2.71823931408338, 2.75603531048692, 2.79419131580901, 2.83273420453703,
                2.87169228624297, 2.91109547399703, 2.95097547200165, 2.9913659856485,
                3.03230295778437, 3.07382483568731, 3.11597287413536, 3.15879148104057,
                3.20232861347727, 3.24663623363113, 3.29177083633315, 3.33779406255307,
                3.38477341668774, 3.43278310993483, 3.48190505782388, 3.53223006754642,
                3.58385926073574, 3.6369057907142, 3.69149693128248, 3.74777663880627,
                3.80590872353856, 3.86608081413139, 3.92850936779173, 3.99344607793656,
                4.06118617816701, 4.13207936322294, 4.20654439027517, 4.28508896719065,
                4.36833742123944, 4.45707013841015, 4.55228138815544, 4.65526696096656,
                4.76776234713669, 4.89217133105485, 5.03196745327713, 5.19245514780686,
                5.3823677339823, 5.61774163484579, 5.93365039826693, 6.43789807886804,
                double.PositiveInfinity
            })
    };

    [UsedImplicitly]
    public static TheoryData<string> TestDataKeys = TheoryDataHelper.Create(TestDataList.Select(it => it.Distribution.ToString()!));

    [Theory]
    [MemberData(nameof(TestDataKeys))]
    public void WeibullDistributionTest(string testKey)
    {
        Check(TestDataList.First(it => it.Distribution.ToString() == testKey));
    }

    [Fact]
    public void WeibullDistributionTest1()
    {
        var weibull = new WeibullDistribution(1);
        AssertEqual("Shape", 1, weibull.Shape);
        AssertEqual("Scale", 1, weibull.Scale);
        AssertEqual("Mean", 1, weibull.Mean);
        AssertEqual("Median", 0.6931471805599453, weibull.Median);
        AssertEqual("Variance", 1, weibull.Variance);
    }

    [Fact]
    public void WeibullDistributionTest2()
    {
        var weibull = new WeibullDistribution(2, 1.5);
        AssertEqual("Shape", 2, weibull.Shape);
        AssertEqual("Scale", 1.5, weibull.Scale);
        AssertEqual("Mean", 1.3293403902848553, weibull.Mean);
        AssertEqual("Median", 1.2488319167365465, weibull.Median);
        AssertEqual("Variance", 0.482854144940259, weibull.Variance);
    }
}