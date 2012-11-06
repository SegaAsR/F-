module QuadParser

// Implementation file for parser generated by fsyacc
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open Microsoft.FSharp.Text.Lexing
open Microsoft.FSharp.Text.Parsing.ParseHelpers
# 1 "QuadParser.fsy"


open Types


# 11 "QuadParser.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | NEG
  | EQ
  | VAR of (System.String)
  | NUM of (System.Int32)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_NEG
    | TOKEN_EQ
    | TOKEN_VAR
    | TOKEN_NUM
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startstart
    | NONTERM_start
    | NONTERM_Equation
    | NONTERM_RightPart
    | NONTERM_LeftPart

// This function maps tokens to integers indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | NEG  -> 1 
  | EQ  -> 2 
  | VAR _ -> 3 
  | NUM _ -> 4 

// This function maps integers indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_NEG 
  | 2 -> TOKEN_EQ 
  | 3 -> TOKEN_VAR 
  | 4 -> TOKEN_NUM 
  | 7 -> TOKEN_end_of_input
  | 5 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startstart 
    | 1 -> NONTERM_start 
    | 2 -> NONTERM_Equation 
    | 3 -> NONTERM_Equation 
    | 4 -> NONTERM_RightPart 
    | 5 -> NONTERM_RightPart 
    | 6 -> NONTERM_LeftPart 
    | 7 -> NONTERM_LeftPart 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 7 
let _fsyacc_tagOfErrorTerminal = 5

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | NEG  -> "NEG" 
  | EQ  -> "EQ" 
  | VAR _ -> "VAR" 
  | NUM _ -> "NUM" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | NEG  -> (null : System.Object) 
  | EQ  -> (null : System.Object) 
  | VAR _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | NUM _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; 1us; 65535us; 0us; 2us; 3us; 65535us; 5us; 6us; 8us; 9us; 11us; 12us; 1us; 65535us; 0us; 4us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; 5us; 9us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 2us; 1us; 2us; 1us; 2us; 1us; 3us; 1us; 3us; 1us; 3us; 1us; 4us; 1us; 5us; 1us; 5us; 1us; 6us; 1us; 7us; 1us; 7us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 7us; 9us; 11us; 13us; 15us; 17us; 19us; 21us; 23us; 25us; |]
let _fsyacc_action_rows = 13
let _fsyacc_actionTableElements = [|2us; 32768us; 1us; 11us; 4us; 10us; 0us; 49152us; 1us; 16385us; 0us; 3us; 0us; 16386us; 1us; 32768us; 2us; 5us; 2us; 32768us; 1us; 8us; 4us; 7us; 0us; 16387us; 0us; 16388us; 2us; 32768us; 1us; 8us; 4us; 7us; 0us; 16389us; 0us; 16390us; 2us; 32768us; 1us; 8us; 4us; 7us; 0us; 16391us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 3us; 4us; 6us; 7us; 9us; 12us; 13us; 14us; 17us; 18us; 19us; 22us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 1us; 2us; 3us; 1us; 2us; 1us; 2us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 2us; 2us; 3us; 3us; 4us; 4us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 65535us; 16386us; 65535us; 65535us; 16387us; 16388us; 65535us; 16389us; 16390us; 65535us; 16391us; |]
let _fsyacc_reductions ()  =    [| 
# 101 "QuadParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data :  Types.Equation )) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (Microsoft.FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : '_startstart));
# 110 "QuadParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Equation)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 24 "QuadParser.fsy"
                                       _1 
                   )
# 24 "QuadParser.fsy"
                 :  Types.Equation ));
# 121 "QuadParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Equation)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 27 "QuadParser.fsy"
                                                    _1 
                   )
# 27 "QuadParser.fsy"
                 : 'Equation));
# 132 "QuadParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'LeftPart)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'RightPart)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 28 "QuadParser.fsy"
                                                    Eq(_1, _3) 
                   )
# 28 "QuadParser.fsy"
                 : 'Equation));
# 144 "QuadParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : System.Int32)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 31 "QuadParser.fsy"
                                                    Int(_1) 
                   )
# 31 "QuadParser.fsy"
                 : 'RightPart));
# 155 "QuadParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'RightPart)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 32 "QuadParser.fsy"
                                                    Neg(_2) 
                   )
# 32 "QuadParser.fsy"
                 : 'RightPart));
# 166 "QuadParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : System.Int32)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 35 "QuadParser.fsy"
                                                    Int(_1) 
                   )
# 35 "QuadParser.fsy"
                 : 'LeftPart));
# 177 "QuadParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'RightPart)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 36 "QuadParser.fsy"
                                                    Neg(_2) 
                   )
# 36 "QuadParser.fsy"
                 : 'LeftPart));
|]
# 189 "QuadParser.fs"
let tables () : Microsoft.FSharp.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:Microsoft.FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 8;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = (tables ()).Interpret(lexer, lexbuf, startState)
let start lexer lexbuf :  Types.Equation  =
    Microsoft.FSharp.Core.Operators.unbox ((tables ()).Interpret(lexer, lexbuf, 0))
