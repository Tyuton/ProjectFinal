SELECT    *    
FROM            Field INNER JOIN
                         Query ON Field.QueryId = Query.QuieryId INNER JOIN
                         Page ON Query.QuieryId = Page.QueryId