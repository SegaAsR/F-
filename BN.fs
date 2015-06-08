open System
open System.Collections.Generic

type Node = string

type Graph<'Node> = list<'Node * 'Node list>

let parents graph target =
    [
        //для каждого элемента списка смежностей
        for (node, childs) in graph do            
        //если в списке детей есть target
            if Seq.exists ((=) target) childs then
                //добавить эту ноду в результирующий список
                yield node        
    ]

let testG = [ ("A", ["B"; "D"]); ("B", []); ("C", ["D"]); ("D", []); ]
//parents testG "D"

let childs graph target = 
    List.filter (fun (node, _) -> node = target) graph
    |> List.head
    |> snd
    
//childs testG "A"


// Читай от сюда

unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Mask, DBCtrls, DB, ADODB;

const
  CountAnswer = 4; // Колличество варинтов ответа
  CountAsk = 6;   // Колличество вопросов на которые надо ответить чтобы стать миллионером
                 // Если хотим больше ввопросов для конца игры увиличеваем эту переменню и вносим изменения в функции на
                 // Строке ~60
type
  TForm1 = class(TForm)
    Variant1: TButton;
    Variant3: TButton;
    Variant2: TButton;
    Variant4: TButton;
    EditQuestion: TDBEdit;
    Button1: TButton;
    QueryQuestion: TADOQuery;
    ADOConnection1: TADOConnection;
    EditAsk: TEdit;
    Label1: TLabel;
    ButtonFifty: TButton;
    ButtonCall: TButton;
    ButtonHelp: TButton;
    Label2: TLabel;
    EditCount: TEdit;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    Label6: TLabel;
    NewGame: TButton;
    procedure Button1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure VariantCheckClick(Sender: TObject);
    procedure ButtonCallClick(Sender: TObject);
    procedure ButtonFiftyClick(Sender: TObject);
    procedure ButtonHelpClick(Sender: TObject);
    procedure NewGameClick(Sender: TObject);
  private
    { Private declarations }
  public
    M: array[1..CountAnswer] of string;
    Indx: array[1..CountAnswer] of integer;
    TrueAsks,r1,r2,r3,r4,r5,r6: integer;
    ololo: string;
   { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}
// НАЖАТИЕ НА КНОПКУ ДАЛЕЕЕ!!!
procedure TForm1.Button1Click(Sender: TObject);
var
  I,J,K,Temp,rn1,rn2,rn3,rn4,rn5,rn6: integer;
begin
 EditQuestion.Clear;
 QueryQuestion.SQL.Clear;

 Randomize;
 rn1:=random(15)+1; //  Выбор вопросов для игры из базы
 rn2:=random(15)+1; // всего в базе 15 вопросов, если нужно больше вопросов в базе том еняем значение 15 на колв вопросов во всей функции
 rn3:=random(15)+1;
 rn4:=random(15)+1;
 rn5:=random(15)+1;
 rn6:=random(15)+1;

 while (rn1=r1) or (rn1=r2) or (rn1=rn6) or (rn1=rn5) or (rn1=rn4) or (rn1=rn3) or (rn1=rn2) or (rn1>5) do begin
 rn1:=random(15)+1;  // Выбор вопроса
 end;

 while (rn2=r1) or (rn2=r2) or (rn2=rn6) or (rn2=rn5) or (rn2=rn4) or (rn2=rn3) or (rn2=rn1) or (rn2>5) do begin
 rn2:=random(15)+1;
 end;

 while (rn3=r3) or (rn3=r4) or (rn3=rn6) or (rn3=rn5) or (rn3=rn4) or (rn3=rn2) or (rn3=rn1) or (rn3<6) or (rn3>10) do begin
 rn3:=random(15)+1;
 end;

 while (rn4=r3) or (rn4=r4) or (rn4=rn6) or (rn4=rn5) or (rn4=rn3) or (rn4=rn2) or (rn4=rn1) or (rn4<6) or (rn4>10) do begin
 rn4:=random(15)+1;
 end;

 while (rn5=r5) or (rn5=r6) or (rn5=rn6) or (rn5=rn4) or (rn5=rn3) or (rn5=rn2) or (rn5=rn1) or (rn5>15) or (rn5<11) do begin
 rn5:=random(15)+1;
 end;

 while (rn6=r5) or (rn6=r6) or (rn6=rn5) or (rn6=rn4) or (rn6=rn3) or (rn6=rn2) or (rn6=rn1) or (rn6>15) or (rn6<11) do begin
 rn6:=random(15)+1;
 end;

 r1:=rn1; //rX вопрос для игры
 r2:=rn2;  // rnX выбранный случайно вопрос для базы
 r3:=rn3;
 r4:=rn4;
 r5:=rn5;
 r6:=rn6;

 //Если надо  болше вопросов в игре то добовляем эти функции
 //r1:=rn1;
 //ShowMessage(IntToStr(rn1)+' '+IntToStr(rn2)+' '+IntToStr(rn3)+' '+IntToStr(rn4)+' '+IntToStr(rn5)+' '+IntToStr(rn6));

 QueryQuestion.SQL.Clear;// Забор вопросов из базы по уровню сложности ( Всего 3 уровня сложности вопросов )

 if (TrueAsks=0) then
 QueryQuestion.SQL.Text := 'SELECT TOP 1 * FROM Questions WHERE (Level=1) AND (id='+IntToStr(rn1)+') AND (ID NOT IN ('+ololo+'));';

 if (TrueAsks=1) then
 QueryQuestion.SQL.Text := 'SELECT TOP 1 * FROM Questions WHERE (Level=1) AND (id='+IntToStr(rn2)+') AND (ID NOT IN ('+ololo+'));';

 if (TrueAsks=2) then
 QueryQuestion.SQL.Text := 'SELECT TOP 1 * FROM Questions WHERE (Level=2) AND (id='+IntToStr(rn3)+') AND (ID NOT IN ('+ololo+'));';

 if (TrueAsks=3) then
 QueryQuestion.SQL.Text := 'SELECT TOP 1 * FROM Questions WHERE (Level=2) AND (id='+IntToStr(rn4)+') AND (ID NOT IN ('+ololo+'));';

 if (TrueAsks=4) then
 QueryQuestion.SQL.Text := 'SELECT TOP 1 * FROM Questions WHERE (Level=3) AND (id='+IntToStr(rn5)+') AND (ID NOT IN ('+ololo+'));';

 if (TrueAsks=5) then
 QueryQuestion.SQL.Text := 'SELECT TOP 1 * FROM Questions WHERE (Level=3) AND (id='+IntToStr(rn6)+') AND (ID NOT IN ('+ololo+'));';

 if (TrueAsks=6) then
 QueryQuestion.SQL.Text := 'SELECT TOP 1 * FROM Questions WHERE (id=0);';

 QueryQuestion.Active := true;

 if ololo<>'' then ololo := ololo + ',';
 ololo := ololo + QueryQuestion.FieldByName('ID').AsString;

 Variant1.Enabled := true;   // Включение кнопок для ответа на вопроса
 Variant2.Enabled := true;
 Variant3.Enabled := true;
 Variant4.Enabled := true;
 Button1.Enabled := false;    // выключение кнопки перехода на следующзий вопрос.

 if TrueAsks=0 then begin  // Если правильных ответов ноль ( начало игры то включем все кнопки помощи)
  ButtonFifty.Enabled := true;
  ButtonCall.Enabled := true;
  ButtonHelp.Enabled := true;
 end;

 if TrueAsks=CountAsk then begin  // Если игра выйграна  то включем все кнопки помощи ( без нее кнопки не всегда включались )
  ButtonFifty.Enabled := true;
  ButtonCall.Enabled := true;
  ButtonHelp.Enabled := true;
 end;

 EditAsk.Text := (IntToStr(TrueAsks));

 M[1] := QueryQuestion.FieldByName('TrueAsk').AsString;   // Если правильный ответ
 for I := 2 to CountAnswer do
 M[I] := QueryQuestion.FieldByName('FalseAsk'+Trim(IntToStr(I-1))).AsString; // Неправильный ответ

 for I := 1 to CountAnswer do
 Indx[I] := I;

 for J := 1 to 100 do    // Генерация случайных индексов для раскидывания ответов на кнопки
   for I := 1 to CountAnswer do begin
     repeat
       K := Random(CountAnswer)+1;
     until K<>I;
   Temp := Indx[K];
   Indx[K] := Indx[I];
   Indx[I] := Temp;
 end;

 EditQuestion.Text := QueryQuestion.FieldByName('Question').AsString; //Вывод вопроса
 Variant1.Caption := M[Indx[1]]; // Привязка ответов к кнопкам
 Variant2.Caption := M[Indx[2]];
 Variant3.Caption := M[Indx[3]];
 Variant4.Caption := M[Indx[4]];

 if TrueAsks=CountAsk then //Если колличество правильных ответов равно максимальному количеству вопросов то вывести информацию о победе!
 begin
 Application.MessageBox('Вы стали миллионером!', 'Поздравляю!!!', MB_OK);
 EditAsk.Text := (IntToStr(TrueAsks));
 TrueAsks:=0;
 Button1.Enabled := false;
 EditQuestion.Clear;
 Variant1.Enabled := false;
 Variant2.Enabled := false;
 Variant3.Enabled := false;
 Variant4.Enabled := false;
 ButtonFifty.Enabled := false;
 ButtonCall.Enabled := false;
 ButtonHelp.Enabled := false;
 end;

 Variant1.Tag := 1;
 Variant2.Tag := 2;
 Variant3.Tag := 3;
 Variant4.Tag := 4;
end;

procedure TForm1.FormCreate(Sender: TObject); //Сама форма
 var
 I,J,K,Temp,rn: integer;
 st: integer;
begin
 ADOConnection1.Connected:=false;
 ADOConnection1.ConnectionString:='Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+  // Подключение базы данных с вопросами в Acssecc
      ExtractFilePath(Application.ExeName)+'Data.mdb;Persist Security Info=False';
 ADOConnection1.Connected:=true;

 EditCount.Text:=IntToStr(CountAsk);

 ololo:='0'; // Счётчик ответов

 for I := 1 to CountAnswer do   // Возврат кнопкам их индексов ( для рандомного раскидывания ответов //
 Indx[I] := 0;

 Variant1.Tag := 1;
 Variant2.Tag := 2;
 Variant3.Tag := 3;
 Variant4.Tag := 4;

 EditQuestion.Clear;     // Блокировка всех кнопок, очистка форм
 QueryQuestion.SQL.Clear;

 Button1.Enabled:= false;
 EditQuestion.Clear;
 Variant1.Enabled := false;
 Variant2.Enabled := false;
 Variant3.Enabled := false;
 Variant4.Enabled := false;
 ButtonFifty.Enabled := false;
 ButtonCall.Enabled := false;
 ButtonHelp.Enabled := false;
end;

procedure TForm1.VariantCheckClick(Sender: TObject);  // Нажатие на 1 из 4 кнопок ответа
var ButtonTag : integer;
begin
 Button1.Enabled := true;

 ButtonTag := TButton(Sender).Tag;      // Проверка тега кнопки ( иногда падала при расскидывани случайных варинтов на кнопку)
 if (ButtonTag<=0) or (ButtonTag>CountAnswer) then begin
  Application.MessageBox('Ошибка при задании тэга кнопки!', 'Ошибка', MB_ICONSTOP or MB_OK);
  Exit;
 end;

 if Indx[ButtonTag] = 0 then begin  //Проверка на дурака
  Application.MessageBox('Вопрос ещё не задан!', 'Ошибка', MB_ICONSTOP or MB_OK);
  Exit;
 end;

 if Indx[ButtonTag]=1 then    //Реакция на павилный или неправильный ответ
  Application.MessageBox('Поздравляю! Правильный ответ!', 'Информация', MB_OK)
   else
    Application.MessageBox('А вот и неверно! Ошибочный ответ!', 'Ошибка', MB_ICONSTOP or MB_OK);

 if Indx[ButtonTag]=1 then begin // Если ответ правильный блокируе все кнопки
  TrueAsks:=TrueAsks+1;
  Variant1.Enabled := false;
  Variant2.Enabled := false;
  Variant3.Enabled := false;
  Variant4.Enabled := false;
  Exit;
 end;

 if Indx[ButtonTag]<>1 then begin // Если неправильный, колличество правильных ответов делаем 0Ю ощищаем все формы, блокируем кнопки
  TrueAsks:=0;
  ButtonFifty.Enabled := false;
  ButtonCall.Enabled := false;
  ButtonHelp.Enabled := false;
  Variant1.Enabled := false;
  Variant2.Enabled := false;
  Variant3.Enabled := false;
  Variant4.Enabled := false;
  Button1.Enabled := false;
  EditQuestion.Clear;
  Exit;
 end;

 if TrueAsks=0 then begin // Если правильных ответов 0 но включаем все подсказщки
  ButtonFifty.Enabled := true;
  ButtonCall.Enabled := true;
  ButtonHelp.Enabled := true;
 end;

 if TrueAsks=CountAsk then begin // Если выйграли игру тов ключаем заного все подсказки
  ButtonFifty.Enabled := true;
  ButtonCall.Enabled := true;
  ButtonHelp.Enabled := true;
 end;

end;

procedure TForm1.ButtonCallClick(Sender: TObject);// Подсказка звонок другу
var ololo: string;
begin
 ButtonCall.Enabled := false;  // Говрит правильный ответ всегда
 ololo:=('- Алло!'+#13+'- Ололо, слющай, *задает вопрос*'+#13+'- Ящитаю, правильный ответ - '+QueryQuestion.FieldByName('TrueAsk').AsString+'!');
 ShowMessage(ololo);
end;

procedure TForm1.ButtonFiftyClick(Sender: TObject);   // 50/50
var K,L,H: integer;
tb,tb1,tb2: TButton;
begin
 Randomize;
 H:= Random(CountAnswer)+1;
 K:= Random(CountAnswer)+1;
 L:= Random(CountAnswer)+1;

 while K=L do begin
 L:= Random(CountAnswer)+1;
 end;

 while (H=K) or (H=L) do begin
 H:= Random(CountAnswer)+1;
 end;

 tb1:= FindComponent('Variant'+IntToStr(K)) as TButton; //Выискиваем кнопку с правильны ответом
 tb2:= FindComponent('Variant'+IntToStr(L)) as TButton;  // Две другие блокируем
 tb:= FindComponent('Variant'+IntToStr(H)) as TButton;

 if tb1.Caption<>QueryQuestion.FieldByName('TrueAsk').AsString then
 begin
 tb1.Enabled:= false;
 end;
 if tb1.Caption=QueryQuestion.FieldByName('TrueAsk').AsString then
 begin
 tb1:=tb;
 tb1.Enabled:= false;
 end;

 if tb2.Caption<>QueryQuestion.FieldByName('TrueAsk').AsString then
 begin
 tb2.Enabled:= false;
 end;
 if tb2.Caption=QueryQuestion.FieldByName('TrueAsk').AsString then
 begin
 tb2:=tb;
 tb2.Enabled:= false;
 end;

 ButtonFifty.Enabled:= false;

 end;

procedure TForm1.ButtonHelpClick(Sender: TObject); // Помощь зала
var
v1,v2,v3,v4: integer; //Соврешенно случайная
begin
 Randomize;
 v1:=random(50); // От 1 до 50%
 v2:=random(100-v1); // От 1 до 100%   -  Вероятность первого
 v3:=random(100-v1-v2); // И так далеее
 v4:=100-v1-v2-v3;
 Showmessage('Вариант a) - '+IntToStr(v1)+'%'+#13+'Вариант b) - '+IntToStr(v2)+'%'+#13+'Вариант c) - '+IntToStr(v3)+'%'+#13+'Вариант d) - '+IntToStr(v4)+'%');

 ButtonHelp.Enabled:= false;

end;

procedure TForm1.NewGameClick(Sender: TObject);// Нажатие кнопки новая игра
var
  I,J,K,Temp,rn,BSelected: integer;
begin
 BSelected:=MessageDlg('Начать новую игру?',mtCustom,[mbYes, mbNo],0);
 if BSelected = mrNo then exit;

 ololo:='0';

 r1:=0;
 r2:=0;
 r3:=0;
 r4:=0;
 r5:=0;
 r6:=0;

 Button1.Click;
 end;

end.
