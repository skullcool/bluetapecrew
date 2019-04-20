import { FETCH_STYLES, NEW_STYLE } from './types'
import { getStyles } from '../Api'


export const fetchStyles = (id) => dispatch => {
  getStyles(id).then((data)=> {
    console.log(data)
    dispatch({
      type: FETCH_STYLES,
      payload: data
    })
  })

}
