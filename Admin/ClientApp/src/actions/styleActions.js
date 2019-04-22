import { FETCH_STYLES, DELETE_STYLE } from './types'
import { deleteStyle, getStyles } from '../Api'


export const fetchStyles = (id) => dispatch => {
  getStyles(id).then((data)=> {
    dispatch({
      type: FETCH_STYLES,
      payload: data
    })
  })
}

export const removeStyle = (id) => dispatch => {
  deleteStyle(id).then(()=> {
    dispatch({
      type: DELETE_STYLE,
      payload: id
    })
  })
}
